namespace PMSClass
{
    class DBOperate
    {
        public static string IP;
        SqlConnection conn = DBConnection.MyConnection(IP);

        public void BindCombobox(ComboBox box,string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            da.Fill(ds);
            box.DataSource = ds.Tables[0];
        }

        public string isOpen()
        {
            return conn.State.ToString();
        }

        public DataSet getTable(string cmd)
        {
            SqlDataAdapter sda = new SqlDataAdapter(cmd,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Dispose();

            return ds;
        }

        public void BindDataGridView(DataGridView dgv,string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        public int OperateDate(string strSql)
        {
            conn.Open();
            MessageBox.Show(strSql);
            SqlCommand cmd = new SqlCommand(strSql,conn);
            int i = (int)cmd.ExecuteNonQuery();

            conn.Close();
            return i;
        }

        public bool hasRow(string strSql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql,conn);
            var s = cmd.ExecuteScalar();

            conn.Close();
            return (s!=null);
        }

        public int insertUnit(string name,string number,int rank)
        {
            return 0;
        }

        public void insertCombobox(ComboBox box,string cmd)
        {
            SqlDataAdapter myDa=new SqlDataAdapter(cmd,conn);
            DataSet myDs=new DataSet();
            myDa.Fill(myDs,"table");
            box.DataSource=myDs.Tables[0];
            box.DisplayMember = "单位名称";
        }

        public void insertCombobox(ComboBox box, string cmd,string name)
        {
            SqlDataAdapter myDa = new SqlDataAdapter(cmd, conn);
            DataSet myDs = new DataSet();
            myDa.Fill(myDs, "table");
            box.DataSource = myDs.Tables[0];
            box.DisplayMember = name;
        }

        public string unitNameIndexFind(string name)
        {
            string cmd = "select 单位序列号 from F_单位列表 where 单位名称='"+name+"'";

            SqlDataAdapter sda = new SqlDataAdapter(cmd,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string getSubjectNameById(string subjectId)
        {
            string cmd = "select 课目名称 from B_考核课目目录 where 1=1 ";
            cmd += "and 课目编号=" + subjectId;

            SqlDataAdapter sda = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public int getPoint(string id)
        {
            string cmd = "select 量化得分 from A_基本信息 where 士兵证号='"+id+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return (int)ds.Tables[0].Rows[0][0];
        }

        public int nameSubjectGetID(string name)
        {
            string cmd = "select 课目编号 from B_考核课目目录 where 1=1 ";
            cmd += "and 课目名称='" + name + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return (int)ds.Tables[0].Rows[0][0];
        }

        public string getSubjectIDByTestID(string id)
        {
            string cmd = "select 考核课目 from B_考核列表 where 1=1 ";
            cmd += "and 考核编号="+id;

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string getSubjectNameByTestID(string id)
        {
            string SubjectID = getSubjectIDByTestID(id);

            string cmd = "select 课目名称 from B_考核课目目录 where 1=1 ";
            cmd += "and 课目编号='" + SubjectID + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string getTestTimeByTestID(string id)//这里是时间格式调整！
        {
            string cmd = "select CONVERT(varchar(100),测试时间,23) from B_考核列表 where 1=1 ";
            //string cmd = "select  测试时间 from B_考核列表 where 1=1 ";
            cmd += "and 考核编号="+id;

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public string getTestTimeByTestId(string id)
        {
            string cmd = "select 测试时间 from B_考核列表 where 1=1 ";
            cmd += "and 考核编号=" + id;

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public DataSet getChartByPersonID(string id,string subject)
        {
            string cmd = "select 考核成绩 from B_考核成绩 where 1=1 ";
            cmd += "and 考核编号=" + subject + " and 士兵证号='" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
