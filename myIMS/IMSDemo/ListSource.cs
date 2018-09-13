using System.Data;

namespace InSystem
{
    class ListSource
    {
        private DataTable DataHead;
        
        public ListSource(System.Windows.Forms.DataGridView dataGridView)
        {
            DataHead = new DataTable();
            DataHead.Columns.AddRange
                (
                    new DataColumn[]
                    { 
                        new DataColumn("学号", typeof(string)), 
                        new DataColumn("姓名", typeof(string)), 
                        new DataColumn("性别", typeof(string)), 
                        new DataColumn("班级", typeof(string)) 
                    } 
                );
            dataGridView.DataSource = DataHead.DefaultView;
        }
        
        public void Add(string sName, string sSex, string sID, string sClass)
        {
            DataRow Row = DataHead.NewRow();
            Row[0] = sName;
            Row[1] = sSex;
            Row[2] = sID;
            Row[3] = sClass;
            DataHead.Rows.Add(Row);
        }

        public void Clear()
        {
            DataHead.Rows.Clear();
        }
    }
}
