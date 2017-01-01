        'private void dgvRefresh()'//单位选择
        {
            string cmd = "select * from A_基本信息 where 1=1 ";
            if(nameBox.Text.Trim()!=string.Empty) cmd += "and 姓名 like '%" + nameBox.Text.Trim() + "%' " ;
            if(genderBox.Text.Trim()!=string.Empty) cmd += "and 性别 like '%" + genderBox.Text.Trim() + "%' ";         

            if (rankBox.SelectedIndex != 0)
                cmd += "and rank="+rankBox.SelectedIndex.ToString();
            //尚未做单位的筛选,利用单位树        

            //MessageBox.Show(cmd);
            operate.BindDataGridView(dgv,cmd);
        }

        ***
        这里主要只出现了
        'like %%' 
        这种类型的正则表达式，其余的内容之后再不断地完善
