using System.Data;
using DomiLibrary.Helper;
using DomiLibrary.Test.Helper.EntityTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class ClassMappingHelperTest
    {
        [TestMethod]
        public void ConvertTest1()
        {
            var a = new A {Property1 = "Property1", Property2 = "Property2", Property3 = 1};
            var b = ClassMappingHelper.Convert<B>(a);

            Assert.AreEqual("Property2", b.Property2);
            Assert.AreEqual(1, b.Property3);
        }

        [TestMethod]
        public void ConvertTest2()
        {
            var a = new A { Property1 = "Property1", Property2 = "Property2", Property3 = 1 };
            var c = ClassMappingHelper.Convert<C>(a);

            Assert.AreEqual(null, c.Property4);
        }

        [TestMethod]
        public void ConvertTest3()
        {
            var ds = new DataSet("ds");
            var table = new DataTable("MiTabla");
            table.Columns.Add("Property4");
            var dr = table.NewRow();
            dr.ItemArray = new object[1];
            dr[0] = "MiPropiedad";
            table.Rows.Add(dr);
            ds.Tables.Add(table);

            var c = ClassMappingHelper.Convert<C>(dr);

            Assert.AreEqual("MiPropiedad", c.Property4);
        }

        [TestMethod]
        public void ConvertTest4()
        {
            var ds = new DataSet("ds");
            var table = new DataTable("MiTabla");
            table.Columns.Add("Property4");
            var dr = table.NewRow();
            dr.ItemArray = new object[1];
            table.Rows.Add(dr);
            ds.Tables.Add(table);

            var c = ClassMappingHelper.Convert<C>(dr);

            Assert.AreEqual(null, c.Property4);
        }

        [TestMethod]
        public void ConvertTest5()
        {
            var ds = new DataSet("ds");
            var table = new DataTable("MiTabla");
            table.Columns.Add("Property3");
            table.Columns.Add("Property2");
            var dr = table.NewRow();
            dr.ItemArray = new object[2];
            dr[0] = 5;
            dr[1] = "MiPropiedad";
            table.Rows.Add(dr);
            ds.Tables.Add(table);

            var b = ClassMappingHelper.Convert<B>(dr);

            Assert.AreEqual("MiPropiedad", b.Property2);
            Assert.AreEqual(5, b.Property3);
        }
    }
}
