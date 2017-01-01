class subjectOperator
{
        //The main point of this function is the using of the identity_number of sql server
       ' public void subjectInsert(string name,string type1,string type2,int jige,int lianghao,int youxiu,string parameter)'
        {
            string cmd = "set IDENTITY_INSERT B_考核课目目录 on \n";
            cmd += "insert B_考核课目目录(课目编号,课目名称,考核类型,评分类型,大纲及格标准,大纲良好标准,大纲优秀标准,成绩单位) ";
            cmd += "values(IDENT_CURRENT('B_考核课目目录')+1, ";
            cmd += "'"+name+"',"+type1+","+type2+","+jige.ToString()+","+lianghao.ToString()+","+youxiu.ToString()+",'"+parameter+"')";
            MessageBox.Show(cmd);
            operate.OperateDate(cmd);
        }
        
        //
        //grammar of sql
        //
        
        
}
