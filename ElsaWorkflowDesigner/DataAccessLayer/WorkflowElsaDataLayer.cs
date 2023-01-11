using ElsaWorkflowDesigner.ViewModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using ElsaWorkflowDesigner.Models;
using System.Text.Json;
using Elsa.Activities.Primitives;
using Elsa.Server.Api.Endpoints.Activities;
using System.Collections.Generic;
using Azure.Core;
using MediatR;
using Elsa.Activities.Workflows.Workflow;
using Microsoft.AspNetCore.Http;
using Parlot.Fluent;
using static Humanizer.In;
using Org.BouncyCastle.Ocsp;
using NetTopologySuite.GeometriesGraph;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using System.Collections;
using Quartz;
using System.Linq;
using Humanizer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Elsa.Models;

namespace ElsaWorkflowDesigner.DataAccessLayer
{
    public class WorkflowElsaDataLayer
    {
        SqlConnection scon = new SqlConnection(Startup.workflowDB);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        RequestBudgetJsonData budget = new RequestBudgetJsonData();
        HttpContext _httpContext;

        public WorkflowElsaDataLayer(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public WorkflowElsaDataLayer()
        {
        }

        public int insertBudgetRequestData(RequestBudgetModel request)
        {
            int requestId = 0;
            budget.RequestedBy = request.RequestedBy;
            budget.BudgetType = getBudgetType(request.BudgetType);
            budget.Amount = request.Amount;
            budget.deptid = request.budgetid;
            string jsonBudgetData = JsonSerializer.Serialize<RequestBudgetJsonData>(budget);
            try
            {
                cmd = new SqlCommand("sp_CreateBudgetRequest", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RequestedBy", SqlDbType.VarChar);
                cmd.Parameters["@RequestedBy"].Value = request.RequestedBy;
                cmd.Parameters.Add("@BudgetData", SqlDbType.VarChar);
                cmd.Parameters["@BudgetData"].Value = jsonBudgetData;
                cmd.Parameters.Add("@RequestedDate", SqlDbType.VarChar);
                DateTime now = DateTime.Now;
                cmd.Parameters["@RequestedDate"].Value = now.ToString();
                scon.Open();
                requestId = (Int32)cmd.ExecuteScalar();
                scon.Close();
                return requestId;
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
                return requestId;
            }
        }
        public List<BudgetType> getBudgetTypeList()
        {
            List<BudgetType> budgets = new List<BudgetType>();

            string sql = "select * from budgettype";
            try
            {
                sda = new SqlDataAdapter(sql, scon);
                scon.Open();
                sda.Fill(dt);
                if(dt != null)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        budgets.Add(new BudgetType
                        {
                            id = (Int32)row["id"],
                            name = row["name"].ToString()
                        });
                    }
                }
                scon.Close();
                
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return budgets;
        }
   
        public string getBudgetType(string budget)
        {
            string budgetType = "";
            try
            {
                cmd = new SqlCommand("select name from budgettype where id = @budget", scon);
                cmd.Parameters.Add("@budget", SqlDbType.VarChar);
                cmd.Parameters["@budget"].Value = budget;
                scon.Open();
                budgetType = cmd.ExecuteScalar().ToString();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return budgetType;
        }
        public void insertDepartmentApprovalData(string budgetid, string empid, string workflowid)
        {


            string workflowData = null;


            //try
            //{
            //    cmd = new SqlCommand(sql, scon);
            //    cmd.Parameters.Add("@Deptid", SqlDbType.VarChar);
            //    cmd.Parameters["@Deptid"].Value = 1;
            //    cmd.Parameters.Add("@Budgetid", SqlDbType.VarChar);
            //    cmd.Parameters["@Budgetid"].Value = Budgetid;
            //    cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
            //    cmd.Parameters["@workflowid"].Value = workflowid;
            //    scon.Open();
            //    cmd.ExecuteNonQuery();
            //    scon.Close();
            //}
            //catch (Exception ex)
            //{
            //    if (scon.State == ConnectionState.Open)
            //    {
            //        scon.Close();
            //    }
            //}

            try
            {
                workflowData = getWorkflowData(workflowid);
                JObject json = JObject.Parse(workflowData);
                int activityCount = Convert.ToInt32(json.SelectToken("activities").Last.Path.Remove(0, 11).Replace(']', ' ').Trim());
                string types = null;
                List<string> ActivityList = new List<string>();
                for (int i = 0; i <= activityCount; i++)
                {
                    string type = json.SelectToken("activities[" + i + "].type").Value<string>();
                    ActivityList.Add(type);
                }

                foreach(var activity in ActivityList)
                {
                    cmd = new SqlCommand("sp_departmentBudgetApproval", scon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empid", SqlDbType.VarChar);
                    cmd.Parameters["@empid"].Value = empid;
                    cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                    cmd.Parameters["@workflowid"].Value = workflowid;
                    cmd.Parameters.Add("@budgetid", SqlDbType.VarChar);
                    cmd.Parameters["@budgetid"].Value = budgetid;
                    cmd.Parameters.Add("@activity", SqlDbType.VarChar);
                    cmd.Parameters["@activity"].Value = activity;
                    scon.Open();
                    cmd.ExecuteNonQuery();
                    scon.Close();
                }
               
                types = string.Join(",", ActivityList);
                cmd = new SqlCommand("sp_WorkflowActivityType", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                cmd.Parameters.Add("@flow", SqlDbType.VarChar);
                cmd.Parameters["@flow"].Value = types;
                cmd.Parameters.Add("@empid", SqlDbType.VarChar);
                cmd.Parameters["@empid"].Value = empid;
                scon.Open();
                cmd.ExecuteNonQuery();
                string update = "UPDATE BudgetRequest set workflowid = @workflowid where id = (SELECT TOP 1 id FROM BudgetRequest ORDER BY ID DESC)";
                cmd = new SqlCommand(update, scon);
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                cmd.ExecuteNonQuery();
                scon.Close();

                //string url = "https://localhost:44370//" + json.SelectToken("activities[0].type").Value<string>();
                //dataLayer.getWorkflowData(workflowid);
                //string insertUrl = "In"
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
        }
        public int getDepartmentId(string empid)
        {
            int returnValue = 0;
            string status = "select deptid from Employee where empid = @empid";
            SqlCommand sqlComm2 = new SqlCommand(status, scon);
            sqlComm2.Parameters.AddWithValue("@empid", empid);
            try
            {
                scon.Open();
                returnValue = (Int32) sqlComm2.ExecuteScalar();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }

            return returnValue;
        }
        public string getDepartmentName(string workflowid)
        {
            string dept = "";
            try
            {
                cmd = new SqlCommand("sp_getDepartmentName", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                scon.Open();
                dept = cmd.ExecuteScalar().ToString();
                return dept;
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return dept;
        }
        public string getGetApproverEmail(string budgetid)
        {
            string email = null;
            try
            {
                cmd = new SqlCommand("sp_getBudgetApproverEmail", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@budgetid", SqlDbType.VarChar);
                cmd.Parameters["@budgetid"].Value = budgetid;
                scon.Open();
                email = cmd.ExecuteScalar().ToString();
                return email;
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return email;
        }
        public string getWorkflowData(string workflowid)
        {
            string workflowDataSql = "select Data from Elsa.WorkflowDefinitions where DefinitionId = @workflowid and IsPublished = 1";
            string workflowData = null;
            try
            {
                cmd = new SqlCommand(workflowDataSql, scon);
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                scon.Open();
                workflowData = cmd.ExecuteScalar().ToString();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return workflowData;
        }
        public string runWorkFlow(string workflowid)
        {
            string flow = null;
            string status = "select flow from WorkflowActivityTypes where workflowid = @workflowid";
            SqlCommand sqlComm2 = new SqlCommand(status, scon);
            sqlComm2.Parameters.AddWithValue("@workflowid", workflowid);
            try
            {
                scon.Open();
                flow = sqlComm2.ExecuteScalar().ToString();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }

            return flow;
        }
        public string getNextWorkFlow(string workflowid, string workflow)
        {

            string flow = null;
            string outFlow = null;
            string status = "select flow from WorkflowActivityTypes where workflowid = @workflowid";
            SqlCommand sqlComm2 = new SqlCommand(status, scon);
            sqlComm2.Parameters.AddWithValue("@workflowid", workflowid);
            try
            {
                scon.Open();
                flow = sqlComm2.ExecuteScalar().ToString();
                scon.Close();
                List<string> flows = flow.Split(',').ToList();
                int index = flows.FindIndex(a => a.Contains(workflow));

                for(int i = 0; i <= index; i++)
                {
                    flows.Remove(flows[i]);
                }
                
                if(flows.Count() > 0)
                {
                    outFlow = flows[0];
                }
                else
                {
                    outFlow = null;
                }
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();   
                }
            }

            return outFlow;
        }
        public void insertApprovalHistory(string workflowid, string RequestedBy, string WorkflowActivity, string Approver, string status)
        {
            string sql = "INSERT INTO ApprovalHistory (Workflowid,RequestedBy,WorkflowActivity,Approver,status) VALUES (@Workflowid,@RequestedBy,@WorkflowActivity,@Approver,@status)";
            try
            {
                cmd = new SqlCommand(sql, scon);
                cmd.Parameters.Add("@Workflowid", SqlDbType.VarChar);
                cmd.Parameters["@Workflowid"].Value = workflowid;
                cmd.Parameters.Add("@RequestedBy", SqlDbType.VarChar);
                cmd.Parameters["@RequestedBy"].Value = RequestedBy;
                cmd.Parameters.Add("@WorkflowActivity", SqlDbType.VarChar);
                cmd.Parameters["@WorkflowActivity"].Value = WorkflowActivity;
                cmd.Parameters.Add("@Approver", SqlDbType.VarChar);
                cmd.Parameters["@Approver"].Value = Approver;
                cmd.Parameters.Add("@status", SqlDbType.VarChar);
                cmd.Parameters["@status"].Value = status;
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
        }
        public List<ApprovalHistory> getApprovalHistory(string workflowid)
        {
            string sql = "select * from ApprovalHistory where workflowid = @workflowid";
            List<ApprovalHistory> result = new List<ApprovalHistory>();
            try
            {
                cmd = new SqlCommand(sql, scon);
                cmd.Parameters.Add("@Workflowid", SqlDbType.VarChar);
                cmd.Parameters["@Workflowid"].Value = workflowid;
                scon.Open();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if(dt != null)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        var data = new ApprovalHistory
                        {
                            Workflowid = row["Workflowid"].ToString(),
                            RequestedBy = row["RequestedBy"].ToString(),
                            Approver = row["Approver"].ToString(),
                            WorkflowActivity = row["WorkflowActivity"].ToString(),
                            status = row["status"].ToString()
                        };
                        result.Add(data);
                    }
                }

                scon.Close();
                sda.Dispose();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return result;
        }

        public void UpdateApprovalHistory(string workflowid, int flowcount)
        {
            string sql = "update workflowprocess set status = 2 where flowcount = @flowcount and workflowid = @workflowid";
            try
            {
                cmd = new SqlCommand(sql, scon);
                cmd.Parameters.Add("@Workflowid", SqlDbType.VarChar);
                cmd.Parameters["@Workflowid"].Value = workflowid;
                cmd.Parameters.Add("@flowcount", SqlDbType.VarChar);
                cmd.Parameters["@flowcount"].Value = flowcount;
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
        }
        public void workflowProcess(string workflowid, int flowcount, string empid, int deptid)
        {
            try
            {
                cmd = new SqlCommand("sp_CreateDepartmentRequest", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                cmd.Parameters.Add("@flowcount", SqlDbType.VarChar);
                cmd.Parameters["@flowcount"].Value = flowcount;
                cmd.Parameters.Add("@empid", SqlDbType.VarChar);
                cmd.Parameters["@empid"].Value = empid;
                cmd.Parameters.Add("@deptid", SqlDbType.VarChar);
                cmd.Parameters["@deptid"].Value = deptid;
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
        }

        public ApprovalContent getWorkflowInfo(string workflowid, int flowCount)
        {
            ApprovalContent result = new ApprovalContent();
            try
            {
                cmd = new SqlCommand("select * from workflowprocess where workflowid=@workflowid and flowcount=@flowcount", scon);
                cmd.Parameters.Add("@workflowid", SqlDbType.VarChar);
                cmd.Parameters["@workflowid"].Value = workflowid;
                cmd.Parameters.Add("@flowCount", SqlDbType.VarChar);
                cmd.Parameters["@flowCount"].Value = flowCount;
                scon.Open();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        result = new ApprovalContent
                        {
                            workflowid = row["Workflowid"].ToString(),
                            RequestedBy = row["RequestedBy"].ToString(),
                            ApproverBy = row["Approverid"].ToString(),
                            ApproverEmail = row["ApproverEmailid"].ToString(),
                            WorkflowData = row["WorkflowData"].ToString(),
                            DeptName = row["DeptName"].ToString()
                        };
                        
                    }
                }

                scon.Close();
                sda.Dispose();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return result;
        }
        public List<DepartmentApprovalHistory> getDeptApprovalList(string dept)
        {
            List<DepartmentApprovalHistory> result = new List<DepartmentApprovalHistory>();
            try
            {
                cmd = new SqlCommand("select * from workflowprocess where approverid=@approverid", scon);
                cmd.Parameters.Add("@approverid", SqlDbType.VarChar);
                cmd.Parameters["@approverid"].Value = dept;
                scon.Open();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var deptment = new DepartmentApprovalHistory
                        {
                            Workflowid = row["Workflowid"].ToString(),
                            RequestedBy = row["RequestedBy"].ToString(),
                            WorkflowData = row["WorkflowData"].ToString(),
                            Status = Convert.ToInt32(row["status"]),
                            url = row["url"].ToString()
                        };
                        result.Add(deptment);
                    }
                }

                scon.Close();
                sda.Dispose();
            }
            catch (Exception ex)
            {
                if (scon.State == ConnectionState.Open)
                {
                    scon.Close();
                }
            }
            return result;
        }

    }
}
