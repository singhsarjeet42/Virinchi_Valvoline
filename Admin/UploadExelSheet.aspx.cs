using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text.RegularExpressions;

public partial class UploadExelSheet : System.Web.UI.Page
{
    static int eMobCount = 0;
    static int eCount = 0, totalCount = 0;
    static string eMsg, totalMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        eMsg = totalMsg = "";
        c1 = c2 = c3 = 0;
        eMobCount = 0;
        eCount = 0;
        totalCount = 0;
    }
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fName = FileUpload1.FileName.ToString();
            string path = string.Empty;
            string fileType = string.Empty;
            string excelConnectionString = string.Empty;

            if (!Directory.Exists(Server.MapPath("~/ExcelSheet")))
            {
                Directory.CreateDirectory(Server.MapPath("~/ExcelSheet"));
            }

            fileType = Path.GetExtension(FileUpload1.FileName).ToLower();
            path = Server.MapPath("~/ExcelSheet/" + fName);

            if(fileType.Trim() == ".xls")
            {
                //excelConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" +
                //      path + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";

                FileUpload1.SaveAs(path);
                //ImportDataFromExcel(excelConnectionString);
                //ImportExcelToSqlServer(path);
                lblMessage.Text = "Invalid File Format.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
            else if(fileType.Trim() == ".xlsx")
            {
                //excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + 
                //    path + ";Extended Properties=Excel 12.0;";
                //FileUpload1.Attributes.Clear();

                FileUpload1.SaveAs(path);
                //ImportDataFromExcel(excelConnectionString);
                //ImportExcelToSqlServer(path);

                //if(FileUpload1.FileBytes.LongLength > 4294967296)
                //{
                //    lblMessage.Text = "File Size Cannot be Exceded By 4 MB.";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //    lblMessage.Visible = true;
                //    Environment.Exit(0);
                //}

                SaveExcelSheet(path);
                File.Delete(path);

                lblMessage.Text = eMsg; 
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;

                lblMsg2.Text = totalMsg;
                lblMsg2.ForeColor = System.Drawing.Color.Green;
                lblMsg2.Visible = true;

                lblMsg3.Text = "No. Of Record Updated : " + c1;
                lblMsg3.ForeColor = System.Drawing.Color.Green;
                lblMsg3.Visible = true;

                lblMsg4.Text = "No. Of Record Duplicated : " + c2;
                lblMsg4.ForeColor = System.Drawing.Color.Green;
                lblMsg4.Visible = true;

                lblMsg5.Text = "No. Of Record Inserted : " + c3;
                lblMsg5.ForeColor = System.Drawing.Color.Green;
                lblMsg5.Visible = true;

                lblMsg6.Text = "No. Of Error Fields : " + eMobCount;
                lblMsg6.ForeColor = System.Drawing.Color.Red;
                //lblMsg6.Visible = true;
            }
            else
            {
                lblMessage.Text = "Invalid File";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
        }
        else
        {
            lblMessage.Text = "Please select excel sheet";
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
        }


    }
    string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString();

    protected DataTable ReadExcelSheetToDataTable(string path)
    {
        ExcelPackage xlPackage = new ExcelPackage();
        var stream = File.OpenRead(path);
        xlPackage.Load(stream);
        ExcelWorksheet ws = xlPackage.Workbook.Worksheets.First();
        DataTable dt = new DataTable(ws.Name);
        stream.Close();

        int totalCols = ws.Dimension.End.Column;
        int totalRows = ws.Dimension.End.Row;
        int startRow = 2;
        ExcelRange wsRows;
        DataRow dr;

        if (totalCols == 22)
        {
            dt.Columns.Add("name_of_person", typeof(string));
            dt.Columns.Add("name_of_outlet", typeof(string));
            dt.Columns.Add("contact_number", typeof(string));
            dt.Columns.Add("pincode", typeof(string));
            //dt.Columns.Add("adhar_number", typeof(string));
            dt.Columns.Add("workshop", typeof(string));
            dt.Columns.Add("segment", typeof(string));
            dt.Columns.Add("counter_potential", typeof(string));
            dt.Columns.Add("no_of_services", typeof(string));
            dt.Columns.Add("valvoline_usage", typeof(string));
            dt.Columns.Add("preferred_retailer", typeof(string));
            dt.Columns.Add("remarks", typeof(string));
            dt.Columns.Add("street_location", typeof(string));
            dt.Columns.Add("state", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("district", typeof(string));
            //dt.Columns.Add("campaign_id", typeof(string));
            dt.Columns.Add("team_name", typeof(string));
            //dt.Columns.Add("near_by_location", typeof(string));
            dt.Columns.Add("organization_source", typeof(string));
            dt.Columns.Add("authenticated_by", typeof(string));
            dt.Columns.Add("authenticated_contact", typeof(string));
            dt.Columns.Add("record_input_form", typeof(string));
            dt.Columns.Add("deleted_on", typeof(string));
            dt.Columns.Add("date_of_birth", typeof(string));
            dt.Columns.Add("source_of_contact", typeof(string));

            for (int rownum = startRow; rownum <= totalRows; rownum++)
            {
                wsRows = ws.Cells[rownum, 1, rownum, totalCols];
                dr = dt.NewRow();
                foreach (var cell in wsRows)
                {
                    dr[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(dr);
            }
        }
        else
        {
            eMsg = "Invalid No. Of Columns, There must be 22 Columns.";
        }

        return dt;
    }

    
    protected void SaveExcelSheet(string path)
    {
        DataTable dt = new DataTable();
        dt = ReadExcelSheetToDataTable(path);

        string name_of_person = "";
        string name_of_outlet = "";
        long contact_number = 0;
        long pincode = 0;
        long adhar_number = 0;
        string workshop = "";
        string segment = "";
        long counter_potential = 0;
        long no_of_services = 0;
        long valvoline_usage = 0;
        string preferred_retailer = "";
        string remarks = "";
        string street_location = "";
        string state = "";
        string city = "";
        string district = "";
        //long campaign_id = 0;
        string team_name = "";
        //string near_by_location = "";
        string organization_source = "";
        string authenticated_by = "";
        string authenticated_contact = "";
        string date_of_birth = "";
        string source_of_contact = "";
        string record_input_form = "Excel Upload";
        bool deleted_on = false;

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < 23;i++ )
                {
                    if ((dr[i]).ToString() == "")
                        dr[i] = "0";
                }
                name_of_person = Convert.ToString(dr[0]);     //Here we are calling the valid method
                name_of_outlet = Convert.ToString(dr[1]);
                bool b1 = ValidMobNo(Convert.ToString(dr[2]));
                if (b1)
                {
                    contact_number = Convert.ToInt64(dr[2]);
                }
                else
                    continue;
                if(contact_number == 0 || name_of_person == "0")
                {
                    eCount = eCount + 1;
                    eMsg = "\nNumber Of Empty (Mobile Number or Mechanic Name) Not Saved : " + eCount + "\n";
                    continue;
                }

                bool b2 = ValidNum(Convert.ToString(dr[3]));
                if (b2)
                {
                    pincode = Convert.ToInt64(dr[3]);
                }
                else
                    continue;

                bool b3 = ValidNum(Convert.ToString(dr[4]));
                if(b3)
                {
                    adhar_number = Convert.ToInt64(dr[4]);
                }
                else
                    continue;
                
                workshop = Convert.ToString(dr[5]);
                segment = Convert.ToString(dr[6]);

                bool b4 = ValidNum(Convert.ToString(dr[7]));
                if(b4)
                {
                    counter_potential = Convert.ToInt64(dr[7]);
                }
                else
                    continue;

                bool b5 = ValidNum(Convert.ToString(dr[8]));
                if(b5)
                {
                    no_of_services = Convert.ToInt64(dr[8]);
                }
                else
                    continue;

                bool b6 = ValidNum(Convert.ToString(dr[9]));
                if(b6)
                {
                    valvoline_usage = Convert.ToInt64(dr[9]);
                }
                else
                    continue;
                
                preferred_retailer = Convert.ToString(dr[10]);
                remarks = Convert.ToString(dr[11]);
                street_location = Convert.ToString(dr[12]);
                state = Convert.ToString(dr[13]);
                city = Convert.ToString(dr[14]);
                district = Convert.ToString(dr[15]);
                //campaign_id = Convert.ToInt64(dr[16]);
                team_name = Convert.ToString(dr[16]);
                //near_by_location = Convert.ToString(dr[17]);
                organization_source = Convert.ToString(dr[17]);
                authenticated_by = Convert.ToString(dr[18]);
                authenticated_contact = Convert.ToString(dr[19]);
                date_of_birth = Convert.ToString(dr[20]);
                source_of_contact = Convert.ToString(dr[21]);
                record_input_form = "Excel Upload";
                deleted_on = false;

                //Here using this method we are inserting the data into the database
                insertdataintosql(name_of_person, name_of_outlet, contact_number, pincode, adhar_number, workshop, segment, counter_potential,
                no_of_services, valvoline_usage, preferred_retailer, remarks, street_location, state, city, district, team_name,
                    /*near_by_location,*/ organization_source, authenticated_by, authenticated_contact, date_of_birth, source_of_contact, record_input_form, deleted_on);
            }
        }

    }

    
    protected bool ValidMobNo(string MobNo)
    {
        bool b1 = true;
        int c = 0;
        if (MobNo.Length != 10)
        {
            eMobCount++;
            b1 = false;
            lblMsg6.Visible = true;
        }
        else
        {
            b1 = MobNo.All(char.IsNumber);
            if(b1 == false)
            {
                eMobCount++;
                b1 = false;
                lblMsg6.Visible = true;
            }
        }
        return b1;
    }

    protected bool ValidNum(string str)
    {
        bool b1 = true;
        b1 = str.All(char.IsNumber);
        if(b1 == false)
        {
            eMobCount++;
            lblMsg6.Visible = true;
        }
        return b1;
    }

    //public void ImportExcelToSqlServer(string ExcelFile)
    //{
    //    Application excel = null;
    //    Workbook wb = null;
    //    Sheets sheet = null;
    //    object missing = Type.Missing;

    //    try
    //    {
    //        btnUpload.Text = "Data Importing In Progress";
    //        btnUpload.Enabled = false;
    //        excel = new Application();
    //        wb = excel.Workbooks.Open(ExcelFile, missing, missing, missing, missing, missing, missing, missing, missing,
    //            missing, missing, missing, missing, missing, missing);

    //        int rowIndex = 2;
    //        int colIndex = 1;
    //        string colType = string.Empty;
    //        string colTypeValue = string.Empty;
    //        string colName = string.Empty;
    //        string colValue = string.Empty;

    //        foreach(Worksheet x in wb.Worksheets)
    //        {
    //            int rowCount = x.Rows.CurrentRegion.EntireRow.Count;
    //            int colCount = x.Columns.CurrentRegion.EntireColumn.Count;

    //            System.Data.DataTable dt = new System.Data.DataTable();
    //            for(int i=2; i<=rowCount; i++)
    //            {
    //                DataRow dr = dt.NewRow();
    //                for(int j = 0; j < colCount; j++)
    //                {
    //                    rowIndex = i;
    //                    colIndex = j + 1;
    //                    if (i == 2)
    //                    {
    //                        colType = ((Range)x.Cells[1, colIndex]).Text.ToString().Trim();
    //                        colName = ((Range)x.Cells[rowIndex, colIndex]).Text.ToString().Trim();
    //                        switch (colType)
    //                        {
    //                            case "varchar":
    //                                colTypeValue = "System.String";
    //                                break;
    //                            case "int":
    //                                colTypeValue = "System.Int32";
    //                                break;
    //                            case "bigint":
    //                                colTypeValue = "System.Int64";
    //                                break;
    //                        }
    //                        dt.Columns.Add(colName, Type.GetType(colTypeValue));
    //                    }
    //                    else
    //                    {
    //                        colValue = ((Range)x.Cells[rowIndex,colIndex]).Text.ToString().Trim();

    //                        dr[j] = colValue;
    //                    }
    //                }
    //                if(i != 2)
    //                {
    //                    dt.Rows.Add(dr);
    //                }
    //            }

    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (System.Data.DataRow dr in dt.Rows)
    //                {
    //                    string name_of_person = "";
    //                    string name_of_outlet = "";
    //                    long contact_number = 0;
    //                    long pincode = 0;
    //                    long adhar_number = 0;
    //                    string workshop = "";
    //                    string segment = "";
    //                    long counter_potential = 0;
    //                    long no_of_services = 0;
    //                    long valvoline_usage = 0;
    //                    string preferred_retailer = "";
    //                    string remarks = "";
    //                    string street_location = "";
    //                    string state = "";
    //                    string city = "";
    //                    string district = "";
    //                    long campaign_id = 0;
    //                    string team_name = "";
    //                    string near_by_location = "";
    //                    string organization_source = "";
    //                    string authenticated_by = "";
    //                    string authenticated_contact = "";
    //                    string record_input_form = "Excel Upload";
    //                    bool deleted_on = false;

    //                    name_of_person = valid1(dr[0].ToString());//Here we are calling the valid method
    //                    name_of_outlet = valid1(dr[1].ToString());
    //                    contact_number = Convert.ToInt64(valid1(dr[2].ToString()));
    //                    pincode = Convert.ToInt64(valid1(dr[3].ToString()));
    //                    adhar_number = Convert.ToInt64(valid1(dr[4].ToString()));
    //                    workshop = valid1(dr[5].ToString());
    //                    segment = valid1(dr[6].ToString());
    //                    counter_potential = Convert.ToInt64(valid1(dr[7].ToString()));
    //                    no_of_services = Convert.ToInt64(valid1(dr[8].ToString()));
    //                    valvoline_usage = Convert.ToInt64(valid1(dr[9].ToString()));
    //                    preferred_retailer = valid1(dr[10].ToString());
    //                    remarks = valid1(dr[11].ToString());
    //                    street_location = valid1(dr[12].ToString());
    //                    state = valid1(dr[13].ToString());
    //                    city = valid1(dr[14].ToString());
    //                    district = valid1(dr[15].ToString());
    //                    campaign_id = Convert.ToInt64(valid1(dr[16].ToString()));
    //                    team_name = valid1(dr[17].ToString());
    //                    near_by_location = valid1(dr[18].ToString());
    //                    organization_source = valid1(dr[19].ToString());
    //                    authenticated_by = valid1(dr[20].ToString());
    //                    authenticated_contact = valid1(dr[21].ToString());
    //                    record_input_form = "Excel Upload";
    //                    deleted_on = false;

    //                    insertdataintosql(name_of_person, name_of_outlet, contact_number, pincode, adhar_number, workshop, segment, counter_potential,
    //                    no_of_services, valvoline_usage, preferred_retailer, remarks, street_location, state, city, district, campaign_id, team_name,
    //                    near_by_location, organization_source, authenticated_by, authenticated_contact, record_input_form, deleted_on);

    //                }
    //            }

    //            //if(dt.Rows.Count > 0)
    //            //{
    //            //    SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString);
    //            //    //SqlConnection con = new SqlConnection(connectionString);
    //            //    //SqlCommand cmd = new SqlCommand();
    //            //    bulkCopy.DestinationTableName = "adminInsValvolineData";
    //            //    bulkCopy.BatchSize = 1000;
    //            //    bulkCopy.ColumnMappings.Add(0, "name_of_person");
    //            //    bulkCopy.ColumnMappings.Add(1, "name_of_outlet");
    //            //    bulkCopy.ColumnMappings.Add(2, "contact_number");
    //            //    bulkCopy.ColumnMappings.Add(3, "pincode");
    //            //    bulkCopy.ColumnMappings.Add(4, "adhar_number");
    //            //    bulkCopy.ColumnMappings.Add(5, "workshop");
    //            //    bulkCopy.ColumnMappings.Add(6, "segment");
    //            //    bulkCopy.ColumnMappings.Add(7, "counter_potential");
    //            //    bulkCopy.ColumnMappings.Add(8, "no_of_services");
    //            //    bulkCopy.ColumnMappings.Add(9, "valvoline_usage");
    //            //    bulkCopy.ColumnMappings.Add(10, "preferred_retailer");
    //            //    bulkCopy.ColumnMappings.Add(11, "remarks");
    //            //    bulkCopy.ColumnMappings.Add(12, "street_location");
    //            //    bulkCopy.ColumnMappings.Add(13, "state");
    //            //    bulkCopy.ColumnMappings.Add(14, "city");
    //            //    bulkCopy.ColumnMappings.Add(15, "district");
    //            //    bulkCopy.ColumnMappings.Add(16, "campaign_id");
    //            //    bulkCopy.ColumnMappings.Add(17, "team_name");
    //            //    bulkCopy.ColumnMappings.Add(18, "near_by_location");
    //            //    bulkCopy.ColumnMappings.Add(19, "organization_source");
    //            //    bulkCopy.ColumnMappings.Add(20, "authenticated_by");
    //            //    bulkCopy.ColumnMappings.Add(21, "authenticated_contact");

    //            //    bulkCopy.WriteToServer(dt);
    //            //    lblMessage.Visible = true;
    //            //    lblMessage.Text = "Table Successfully Imported.";
    //            //    lblMessage.ForeColor = Color.Green;
    //            //}

    //        }
    //    }
    //    catch(COMException ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.ForeColor = Color.Red;
    //        lblMessage.Text = "Error accessing Excel: " + ex.ToString();
    //    }
    //    catch(Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.ForeColor = Color.Red;
    //        lblMessage.Text = "Error: " + ex.Message;
    //    }
    //    finally
    //    {
    //        btnUpload.Enabled = true;
    //        btnUpload.Text = "Upload Excel Sheet";
    //    }
    //}





    //public void ImportDataFromExcel(string excelConnectionString)
    //{
    //    OleDbConnection oconn = new OleDbConnection(excelConnectionString);

    //    try
    //    {
    //        //After connecting to the Excel sheet here we are selecting the data 
    //        //using select statement from the Excel sheet
    //        OleDbCommand ocmd = new OleDbCommand("select name_of_person, name_of_outlet, contact_number, pincode," +
    //        "adhar_number, workshop, segment, counter_potential, no_of_services, valvoline_usage, preferred_retailer," +
    //        "remarks, street_location, state, city, district, campaign_id, team_name, near_by_location, organization_source," +
    //        "authenticated_by,authenticated_contact from [Sheet1$]", oconn);

    //        oconn.Open();
    //        OleDbDataReader odr = ocmd.ExecuteReader();
    //        string name_of_person = "";
    //        string name_of_outlet = "";
    //        long contact_number = 0;
    //        long pincode = 0;
    //        long adhar_number = 0;
    //        string workshop = "";
    //        string segment = "";
    //        long counter_potential = 0;
    //        long no_of_services = 0;
    //        long valvoline_usage = 0;
    //        string preferred_retailer = "";
    //        string remarks = "";
    //        string street_location = "";
    //        string state = "";
    //        string city = "";
    //        string district = "";
    //        long campaign_id = 0;
    //        string team_name = "";
    //        string near_by_location = "";
    //        string organization_source = "";
    //        string authenticated_by = "";
    //        string authenticated_contact = "";
    //        string record_input_form = "Excel Upload";
    //        bool deleted_on = false;

    //        while (odr.Read())
    //        {
    //            name_of_person = valid(odr, 0);//Here we are calling the valid method
    //            name_of_outlet = valid(odr, 1);
    //            contact_number = Convert.ToInt64(valid(odr, 2));
    //            pincode = Convert.ToInt64(valid(odr, 3));
    //            adhar_number = Convert.ToInt64(valid(odr, 4));
    //            workshop = valid(odr, 5);
    //            segment = valid(odr, 6);
    //            counter_potential = Convert.ToInt64(valid(odr, 7));
    //            no_of_services = Convert.ToInt64(valid(odr, 8));
    //            valvoline_usage = Convert.ToInt64(valid(odr, 9));
    //            preferred_retailer = valid(odr, 10);
    //            remarks = valid(odr, 11);
    //            street_location = valid(odr, 12);
    //            state = valid(odr, 13);
    //            city = valid(odr, 14);
    //            district = valid(odr, 15);
    //            campaign_id = Convert.ToInt64(valid(odr, 16));
    //            team_name = valid(odr, 17);
    //            near_by_location = valid(odr, 18);
    //            organization_source = valid(odr, 19);
    //            authenticated_by = valid(odr, 20);
    //            authenticated_contact = valid(odr, 21);
    //            record_input_form = "Excel Upload";
    //            deleted_on = false;

    //            //Here using this method we are inserting the data into the database
    //            insertdataintosql(name_of_person, name_of_outlet, contact_number, pincode, adhar_number, workshop, segment, counter_potential,
    //                no_of_services, valvoline_usage, preferred_retailer, remarks, street_location, state, city, district, campaign_id, team_name,
    //                near_by_location, organization_source, authenticated_by, authenticated_contact, record_input_form, deleted_on);
    //        }
    //        oconn.Close();
    //    }
    //    catch (DataException ee)
    //    {
    //        lblMessage.Text = ee.Message;
    //        lblMessage.ForeColor = System.Drawing.Color.Red;
    //        lblMessage.Visible = true;
    //    }
    //    finally
    //    {
    //        lblMessage.Text = "Data Inserted Sucessfully";
    //        lblMessage.ForeColor = System.Drawing.Color.Green;
    //        lblMessage.Visible = true;
    //    }
    //}

    static int c1, c2, c3;
    public void insertdataintosql(string name_of_person, string name_of_outlet, long contact_number, long pincode, long adhar_number, string workshop, string segment, long counter_potential,
                    long no_of_services, long valvoline_usage, string preferred_retailer, string remarks, string street_location, string state, string city, string district, //long campaign_id,
                    string team_name, /*string near_by_location,*/ string organization_source, string authenticated_by, string authenticated_contact, string date_of_birth, string source_of_contact, 
                    string record_input_form, bool deleted_on)
    {   //inserting data into the Sql Server
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        //cmd.CommandText = "insert into tblvalvoline_detail(name_of_person,name_of_outlet,contact_number,pincode,adhar_number,workshop,segment,counter_potential," +
        //            "no_of_services,valvoline_usage,preferred_retailer,remarks,street_location,state,city,district,campaign_id,team_name," +
        //            "near_by_location, organization_source, authenticated_by, authenticated_contact, record_input_form, deleted_on)" +
        //            "values(@name_of_person,@name_of_outlet,@contact_number,@pincode,@adhar_number,@workshop,@segment,@counter_potential," +
        //            "@no_of_services,@valvoline_usage,@preferred_retailer,@remarks,@street_location,@state,@city,@district,@campaign_id," +
        //            "@team_name, @near_by_location, @organization_source, @authenticated_by, @authenticated_contact, @record_input_form, @deleted_on)";

        cmd.Parameters.Add("@name_of_person", SqlDbType.VarChar).Value = name_of_person;
        cmd.Parameters.Add("@name_of_outlet", SqlDbType.VarChar).Value = name_of_outlet;
        cmd.Parameters.Add("@contact_number", SqlDbType.BigInt).Value = contact_number;
        cmd.Parameters.Add("@pincode", SqlDbType.BigInt).Value = pincode;
        cmd.Parameters.Add("@adhar_number", SqlDbType.BigInt).Value = adhar_number;
        cmd.Parameters.Add("@workshop", SqlDbType.VarChar).Value = workshop;
        cmd.Parameters.Add("@segment", SqlDbType.VarChar).Value = segment;
        cmd.Parameters.Add("@counter_potential", SqlDbType.BigInt).Value = counter_potential;
        cmd.Parameters.Add("@no_of_services", SqlDbType.BigInt).Value = no_of_services;
        cmd.Parameters.Add("@valvoline_usage", SqlDbType.BigInt).Value = valvoline_usage;
        cmd.Parameters.Add("@preferred_retailer", SqlDbType.VarChar).Value = preferred_retailer;
        cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = remarks;
        cmd.Parameters.Add("@street_location", SqlDbType.VarChar).Value = street_location;
        cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
        cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
        cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = district;
        //cmd.Parameters.Add("@campaign_id", SqlDbType.BigInt).Value = campaign_id;
        cmd.Parameters.Add("@team_name", SqlDbType.VarChar).Value = team_name;
        //cmd.Parameters.Add("@near_by_location", SqlDbType.VarChar).Value = near_by_location;
        cmd.Parameters.Add("@organization_source", SqlDbType.VarChar).Value = organization_source;
        cmd.Parameters.Add("@authenticated_by", SqlDbType.VarChar).Value = authenticated_by;
        cmd.Parameters.Add("@authenticated_contact", SqlDbType.VarChar).Value = authenticated_contact;
        cmd.Parameters.Add("@date_of_birth", SqlDbType.VarChar).Value = date_of_birth;
        cmd.Parameters.Add("@source_of_contact", SqlDbType.VarChar).Value = source_of_contact;
        cmd.Parameters.Add("@record_input_form", SqlDbType.VarChar).Value = record_input_form;
        cmd.Parameters.Add("@deleted_on", SqlDbType.Bit).Value = deleted_on;

        cmd.CommandText = "adminInsValvolineData";
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        //int i = cmd.ExecuteNonQuery();
        SqlDataReader reader = cmd.ExecuteReader();
        if(reader.HasRows)
        {
            reader.Read();
            string dataMsg = reader.GetString(0);
            if(dataMsg.Contains("Record Updated"))
            { c1 = c1 + 1; }
            else if (dataMsg.Contains("Record Inserted In Duplicate Machanic"))
            { c2 = c2 + 1; }
            else if(dataMsg.Contains("Record Inserted In Main Machanic"))
            { c3 = c3 + 1; }
        }
        conn.Close();
        //if(i>= 0)
        //{
        //    totalCount = totalCount + 1;
        //    totalMsg = "No. Records Saved to the DataBase : " + totalCount;
        //}
    }

    protected string valid(OleDbDataReader myreader, int stval)//if any columns are 
    //found null then they are replaced by zero
    {
        object val = myreader[stval];
        if (val != DBNull.Value)
            return val.ToString();
        else
            return Convert.ToString(0);
    }

    //protected string validNum(string data)//if any columns are 
    ////found null then they are replaced by zero
    //{
    //    if (data != "")
    //        return data;
    //    else
    //        return Convert.ToString(0);
    //}

    protected void BtbDownload_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("../SampleSheet/Sample ExcelSheet.xlsx");
        FileInfo file = new FileInfo(filepath);
        if (file.Exists)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Type", "application/Excel");
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            lblMessage.Text = "File Does Not Exists.";
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
        }
    }
}