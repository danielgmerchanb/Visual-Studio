using LauncherVerifier.XML;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Launcher.test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para IReaderXMLTest y se pretende que
    ///contenga todas las pruebas unitarias IReaderXMLTest.
    ///</summary>
    [TestClass()]
    public class IReaderXMLTest
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


        internal virtual IReaderXML CreateIReaderXML()
        {
            // TODO: Crear instancia de una clase concreta apropiada.
            IReaderXML target = new ReaderXML();
            return target;
        }

        /// <summary>
        ///Una prueba de GetCompany
        ///</summary>
        [TestMethod()]
        public void GetCompanyTest()
        {
            IReaderXML target = CreateIReaderXML(); // TODO: Inicializar en un valor adecuado
            string Path = @"C:\Total\New\Total\Companies_COL_F_1.xml"; // TODO: Inicializar en un valor adecuado
            string IdCompany = "15465015"; // TODO: Inicializar en un valor adecuado
            string expected = string.Empty; // TODO: Inicializar en un valor adecuado
            string actual;
            actual = target.GetCompany(Path, IdCompany);

            
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
