using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using Common;
using System.Collections.Generic;
using System.Linq;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            string username = "Admin";
            string password = "password";

            bool check = new UsersBL().Login(username, password);

            Assert.AreEqual(check, true);
        }

        [TestMethod]
        public void TestNew()
        {
            BusinessLayer.AssessmentsBL assess = new BusinessLayer.AssessmentsBL();
            List<Assessment> asm = assess.GetAssessments().ToList();
            int count = asm.Count;
            Guid gud = Guid.NewGuid();
            DateTime date = DateTime.Now;

            Assessment a = new Assessment() { AssesmentId = gud, Date = date.Date, duration = 5, time = date.ToString("HH:mm"), AssesmentType_fk = new Guid("d728a9e6-76fc-4daa-8ed3-6960e98ba4d4"), Worker_fk = new Guid("8901adf4-0164-4951-a4c1-71c2c8b297a6"), Origin_fk = new Guid("fa549819-b9ed-470c-b12c-1ad6f7e4321a"), Description = "hai", ConfirmationDate = date.Date, PatientId_fk = 1 };

            
            assess.AddAssessment(a);

            asm = assess.GetAssessments().ToList();

            Assert.IsTrue(asm.Count > count);
        }

        [TestMethod]
        public void TestSearch()
        {
            Guid gud = new Guid("2fe43c86-a52e-4d7f-a203-f8f2821e5e4c");
            
            BusinessLayer.AssessmentsBL assess = new BusinessLayer.AssessmentsBL();
            Assessment a = assess.GetAssessment(gud);
            
            Assert.IsNotNull(a);
        }
    }
}
