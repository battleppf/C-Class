        'private void dgvRefresh()'//单位选择
        {
            string cmd = "select * from A_基本信息 where 1=1 ";
            if(nameBox.Text.Trim()!=string.Empty) cmd += "and 姓名 like '%" + nameBox.Text.Trim() + "%' " ;
            if(genderBox.Text.Trim()!=string.Empty) cmd += "and 性别 like '%" + genderBox.Text.Trim() + "%' ";
            if(partyBox.Text.Trim()!=string.Empty)cmd += "and 政治面貌 like '%" + partyBox.Text.Trim() + "%' ";

            if (rankBox.SelectedIndex != 0)
                cmd += "and 军衔="+rankBox.SelectedIndex.ToString();
            //尚未做单位的筛选,利用单位树
            //还有政治面貌

            //MessageBox.Show(cmd);
            operate.BindDataGridView(dgv,cmd);
        }
