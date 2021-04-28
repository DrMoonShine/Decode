using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Vigenere.Tests
{
    [TestClass]
    public class VigenereOpenTextTests
    {
        [TestMethod]
        public void OpenFile_DirectoriesDoNotExist_NullReturn()
        {
            //arrange
            
            //act
            var check = VigenereText.OpenFile("NoPath");

            //assert
            Assert.IsNull(check);
        }
        [TestMethod]
        public void OpenFile_EmptyFile_NullReturn()
        {
            //arrange
            string path = Path.GetFullPath("checkForEmpty.txt");
            //act
            var check = VigenereText.OpenFile(path);
     
            //assert
           
            Assert.IsNull(check);
        }
        [TestMethod]
        public void OpenFile_NotEmptyFile_NullReturn()
        {
            //arrange
            string path = Path.GetFullPath("checkForNotEmpty.txt");
            //act
            var check = VigenereText.OpenFile(path);

            //assert

            Assert.IsNotNull(check);
        }
        [TestMethod]
        public void DecodeOrEncode_WrongKey_NullReturn()
        {
            //arrange
            var text = new VigenereText();
            text.AllText.Add("тестовая строка");
            //act
            var check = VigenereText.DecodeOrEncode("123_asdW",text,true);

            //assert

            Assert.IsNull(check);

        }
        [TestMethod]
        public void DecodeOrEncode_NullText_NullReturn()
        {
            //arrange
            //act
            var check = VigenereText.DecodeOrEncode("ключ", null, true);

            //assert

            Assert.IsNull(check);

        }
        [TestMethod]
        public void DecodeOrEncode_CorrectKeyAndNotNullText_NullReturn()
        {
            //arrange
            var text = new VigenereText();
            text.AllText.Add("тестовая строка");
            //act
            var check = VigenereText.DecodeOrEncode("ключ", text, true);

            //assert

            Assert.IsNotNull(check);

        }

    }

}
