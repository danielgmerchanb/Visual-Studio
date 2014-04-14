using LauncherVerifier.XML;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LauncherVerifier.Models;
using System.Collections.Generic;
using System.Linq;

namespace Launcher.test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para ReaderXMLTest y se pretende que
    ///contenga todas las pruebas unitarias ReaderXMLTest.
    ///</summary>
    [TestClass()]
    public class ReaderXMLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de GetSummary
        ///</summary>
        [TestMethod()]
        public void GetSummaryTest()
        {
            ReaderXML target = new ReaderXML(); 
            string File = @"C:\Total\Total\Companies_COL_F_1.xml";
            List<SummaryEntity> ret = new List<SummaryEntity>();
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_2.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_3.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_4.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_5.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_6.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_7.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_8.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_9.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_10.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_11.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_12.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_13.xml";
            ret.Add(target.GetSummary(File));
            File = @"C:\Total\Total\Companies_COL_F_14.xml";
            ret.Add(target.GetSummary(File));
            SummaryEntity total = new SummaryEntity
            {
                BranchCount = ret.Sum(q => q.BranchCount),
                CompanyCount = ret.Sum(q => q.CompanyCount),
                File = "Total",
                ListingCount = ret.Sum(q => q.ListingCount),
                MicrositeCount = ret.Sum(q => q.MicrositeCount),
                ProductCount = ret.Sum(q => q.ProductCount),
                SponsorCount = ret.Sum(q => q.SponsorCount)
            };
        }
    }
}
