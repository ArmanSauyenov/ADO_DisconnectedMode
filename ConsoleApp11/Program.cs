using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        private static SqlConnection con = new SqlConnection();

        static void Main(string[] args)
        {
            con.ConnectionString = @"Data Source=(LocalDB)\LocalDBQ;Initial Catalog=CRCMS_new; User ID=sa;Password=Qwerty123";

            DataSet ds = new DataSet("ds");
            DataTable TrackEvaluationPartTable = ds.Tables.Add("TrackEvaluationPart");
            //ds.Tables.Add(TrackEvaluationPartTable);

            DataColumn EvaluationPartId = new DataColumn("EvaluationPartId", Type.GetType("System.Int32"));
            EvaluationPartId.Unique = true;
            EvaluationPartId.AllowDBNull = false;
            EvaluationPartId.AutoIncrement = true;
            EvaluationPartId.AutoIncrementSeed = 1;
            EvaluationPartId.AutoIncrementStep = 1;

            DataColumn floatQuantity = new DataColumn("floatQuantity", Type.GetType("System.Decimal"));
            floatQuantity.DefaultValue = 0;

            DataColumn Description = new DataColumn("Description", Type.GetType("System.String"));
            Description.DefaultValue = "";

            TrackEvaluationPartTable.Columns.Add(EvaluationPartId);
            TrackEvaluationPartTable.Columns.Add(floatQuantity);
            TrackEvaluationPartTable.Columns.Add(Description);

            TrackEvaluationPartTable.PrimaryKey = new DataColumn[] { TrackEvaluationPartTable.Columns["EvaluationPartId"] };

            DataTable TrackComponent = ds.Tables.Add("TrackComponent");

            DataColumn TrackComponentId = new DataColumn("TrackComponentId", Type.GetType("System.Int32"));
            TrackComponentId.Unique = true;
            TrackComponentId.AllowDBNull = false;
            TrackComponentId.AutoIncrement = true;
            TrackComponentId.AutoIncrementSeed = 1;
            TrackComponentId.AutoIncrementStep = 1;

            DataColumn ComponentId = new DataColumn("ComponentId", Type.GetType("System.String"));
            ComponentId.DefaultValue = "";

            DataColumn TrackComponentEvaluationPartId = new DataColumn("EvaluationPartId", Type.GetType("System.Int32"));


            TrackComponent.Columns.Add(TrackComponentId);
            TrackComponent.Columns.Add(ComponentId);
            TrackComponent.Columns.Add(TrackComponentEvaluationPartId);

            TrackComponent.PrimaryKey = new DataColumn[] { TrackComponent.Columns["TrackComponentId"] };

            ds.Relations.Add("TrackCompEvalutionPart", TrackEvaluationPartTable.Columns["EvaluationPartId"], TrackComponent.Columns["EvaluationPartId"]);

            DataRow alliance = TrackEvaluationPartTable.NewRow();
            alliance.ItemArray = new object[] { null, 525, "Alliance" };
            TrackEvaluationPartTable.Rows.Add(alliance);
            DataRow horde = TrackEvaluationPartTable.NewRow();
            horde.ItemArray = new object[] { null, 525, "Horde" };
            TrackEvaluationPartTable.Rows.Add(horde);
            DataRow nightElfs = TrackEvaluationPartTable.NewRow();
            nightElfs.ItemArray = new object[] { null, 525, "Night elfs" };
            TrackEvaluationPartTable.Rows.Add(nightElfs);
            DataRow undead = TrackEvaluationPartTable.NewRow();
            undead.ItemArray = new object[] { null, 525, "Undead" };
            TrackEvaluationPartTable.Rows.Add(undead);

            DataRow guldan = TrackComponent.NewRow();
            guldan.ItemArray = new object[] { null, "Guldan", horde["EvaluationPartId"] };
            TrackComponent.Rows.Add(guldan);

            DataRow maiev = TrackComponent.NewRow();
            maiev.ItemArray = new object[] { null, "Maiev Shadowsong", nightElfs["EvaluationPartId"] };
            TrackComponent.Rows.Add(maiev);

            DataRow sylvanas = TrackComponent.NewRow();
            sylvanas.ItemArray = new object[] { null, "Sylvanas Windrunner", undead["EvaluationPartId"] };
            TrackComponent.Rows.Add(sylvanas);

            DataRow arthas = TrackComponent.NewRow();
            arthas.ItemArray = new object[] { null, "Arthas Menethil", undead["EvaluationPartId"] };
            TrackComponent.Rows.Add(arthas);

            DataRow thrall = TrackComponent.NewRow();
            thrall.ItemArray = new object[] { null, "Thrall", horde["EvaluationPartId"] };
            TrackComponent.Rows.Add(thrall);

            DataRow illidan = TrackComponent.NewRow();
            illidan.ItemArray = new object[] { null, "Illidan", nightElfs["EvaluationPartId"] };
            TrackComponent.Rows.Add(illidan);

            DataRow kaelthas = TrackComponent.NewRow();
            kaelthas.ItemArray = new object[] { null, "Kaelthas Sunstrider", alliance["EvaluationPartId"] };
            TrackComponent.Rows.Add(kaelthas);

            DataRow jaina = TrackComponent.NewRow();
            jaina.ItemArray = new object[] { null, "Lady Jaina Proudmoore", alliance["EvaluationPartId"] };
            TrackComponent.Rows.Add(jaina);

            void show()
            {
                Console.WriteLine("{0, -25}{1, -25}{2}", "EvaluationPartId", "floatQuantity", "Description");
                Console.WriteLine();
                foreach (DataRow row in TrackEvaluationPartTable.Rows)
                {
                    foreach (var column in row.ItemArray)
                    {
                        Console.Write("{0, -25}", column);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n----------------------------------------------------------------------------------\n");
                Console.WriteLine("{0, -25}{1, -25}{2}", "TrackComponentId", "ComponentId", "TrackComponentEvaluationPartId");
                Console.WriteLine();
                foreach (DataRow row in TrackComponent.Rows)
                {
                    foreach (var column in row.ItemArray)
                    {
                        Console.Write("{0, -25}", column);
                    }
                    Console.WriteLine();
                }
            }

            show();
        }
    }
}
