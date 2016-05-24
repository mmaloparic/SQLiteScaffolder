using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite.Scaffolder.Tests.Components;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SQLite.Scaffolder.Tests
{
    [TestClass]
    public class ScaffolderTests
    {
        private const string PrefferedDatabaseName = "ScaffolderTest";
        

        [TestMethod]
        public void CreateDatabase()
        {
            TestDatabase testDatabase = new TestDatabase(PrefferedDatabaseName);
            string databaseFilePath = string.Format("{0}\\{1}.sqlite", Environment.CurrentDirectory, testDatabase.Name);

            //if the database already exists, delete it
            if (File.Exists(databaseFilePath))
                File.Delete(databaseFilePath);

            testDatabase.CreateNewFile();
            Assert.IsTrue(File.Exists(databaseFilePath));

            File.Delete(databaseFilePath);
        }

        [TestMethod]
        public void InsertSelectEditAndDelete()
        {
            //define the database connnection
            TestDatabase testDatabase = new TestDatabase(PrefferedDatabaseName);
            string databaseFilePath = string.Format("{0}\\{1}.sqlite", Environment.CurrentDirectory, testDatabase.Name);

            if (File.Exists(databaseFilePath))
                File.Delete(databaseFilePath);

            testDatabase.CreateNewFile();            

            //add the values to test against
            string preEditText = "pre-edit text";
            string postEditText = "post-edit text";
            int preEditNumeric = 1;
            int postEditNumeric = 2;
            decimal preEditDecimal = 1.5m;
            decimal postEditDecimal = 2.5m;
            DateTime preEditDate = DateTime.Now;
            DateTime postEditDate = preEditDate.AddDays(1);

            //create the entity
            TestEntity initialEntity = new TestEntity();
            initialEntity.ID = new Guid("7b78bd4b-f094-4011-b33b-a6062c9533aa");
            initialEntity.TextProperty = preEditText;
            initialEntity.DecimalProperty = preEditDecimal;
            initialEntity.NumberProperty = preEditNumeric;
            initialEntity.DateProperty = preEditDate;
            initialEntity.ImageBytesProperty = null;

            //insert it to the database
            testDatabase.TestTable.Insert(initialEntity);

            //select the entity from the database
            string whereCondition = string.Format("IdColumn = '{0}'", initialEntity.ID.ToString());
            TestEntity retrievedEntity = testDatabase.TestTable.SelectAll(whereCondition).First();

            //check if we got the entity
            if (retrievedEntity == null)
            {
                Assert.Fail("Could not retrieve the test entity - it was not inserted or select does not work!");
            }
            else
            {
                //check if we got the proper values
                bool allValuesMatch = true;

                if
                    (
                    retrievedEntity.ID != initialEntity.ID
                    || retrievedEntity.TextProperty != preEditText
                    || retrievedEntity.NumberProperty != preEditNumeric
                    || retrievedEntity.DecimalProperty != preEditDecimal
                    || retrievedEntity.DateProperty != preEditDate
                    || retrievedEntity.ImageBytesProperty != null
                    )
                {
                    allValuesMatch = false;
                }

                Assert.IsTrue(allValuesMatch, "Values retrieved from the database did not match!");
            }

            //edit the entity
            retrievedEntity.TextProperty = postEditText;
            retrievedEntity.DecimalProperty = postEditDecimal;
            retrievedEntity.NumberProperty = postEditNumeric;
            retrievedEntity.DateProperty = postEditDate;
            retrievedEntity.ImageBytesProperty = null;

            //update the value
            testDatabase.TestTable.Update(retrievedEntity);

            //select the entity again and check if the values were updated properly
            TestEntity entityAfterUpdate = testDatabase.TestTable.SelectAll(whereCondition).FirstOrDefault();
            if (entityAfterUpdate == null)
            {
                Assert.Fail("Could not retrieve the test entity after update - it was not updated properly or select does not work!");
            }
            else
            {
                bool allValuesMatchAfterUpdate = true;
                if
                    (
                    entityAfterUpdate.ID != entityAfterUpdate.ID
                    || entityAfterUpdate.TextProperty != postEditText
                    || entityAfterUpdate.NumberProperty != postEditNumeric
                    || entityAfterUpdate.DecimalProperty != postEditDecimal
                    || entityAfterUpdate.DateProperty != postEditDate
                    || entityAfterUpdate.ImageBytesProperty != null
                    )
                {
                    allValuesMatchAfterUpdate = false;
                }

                Assert.IsTrue(allValuesMatchAfterUpdate, "Entity was not updated properly - values are missmatched!");
            }

            //now delete the entity
            testDatabase.TestTable.Delete(entityAfterUpdate);

            //check if the entity was really deleted
            bool entityStillExists = testDatabase.TestTable.SelectAll(whereCondition).Any();

            Assert.IsFalse(entityStillExists, "Entity was not deleted as expected, as it was still found!");
        }
    }
}
