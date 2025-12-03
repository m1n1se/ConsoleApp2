using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZadanieNorbit.Tests
{
    [TestClass()]
    public class ZadanieTests
    {
        // Тест проверяет, что функция правильно находит слово в строке, 
        // когда символы слова идут в правильном порядке (не обязательно подряд)
        [DataRow("hello world", "hello", true)]
        [DataRow("hellothere", "hello", true)]  // Проверка: слово в начале строки
        [DataRow("say hello", "hello", true)]   // Проверка: слово в конце строки
        [DataRow("hheelllloo", "hello", true)]  // Проверка: повторяющиеся символы
        [DataRow("ahhellllloou", "hello", true)] // Проверка: дополнительные символы между буквами слова
        [DataRow("abcde", "ace", true)]         // Проверка: поиск подпоследовательности "ace" в "abcde"
        [TestMethod()]
        public void GetRepeatedLetters_CorrectParams_ReturnsTrue(string input, string word, bool expectedResult)
        {
            // Act - выполняем тестируемую функцию
            var actualResult = Zadanie.GetRepeatedLetters(input, word);

            // Assert - проверяем, что результат соответствует ожидаемому
            Assert.AreEqual(expectedResult, actualResult, $"Строка '{input}' должна содержать '{word}'");
        }

        // Тест проверяет случаи, когда функция должна вернуть false
        // (слово не содержится в строке в правильном порядке)
        [DataRow("world", "hello", false)]      // Проверка: строка не содержит слово
        [DataRow("olleh", "hello", false)]      // Проверка: буквы в обратном порядке
        [DataRow("hhelo", "hello", false)]      // Проверка: не хватает одной буквы 'l'
        [DataRow("abcde", "aec", false)]        // Проверка: буквы в неправильном порядке
        [DataRow("hel", "hello", false)]        // Проверка: слово длиннее строки
        [DataRow("abcdef", "z", false)]         // Проверка: символа 'z' нет в строке
        [TestMethod()]
        public void GetRepeatedLetters_CorrectParams_ReturnsFalse(string input, string word, bool expectedResult)
        {
            // Act
            var actualResult = Zadanie.GetRepeatedLetters(input, word);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, $"Строка '{input}' не должна содержать '{word}'");
        }

        // Тест проверяет чувствительность метода к регистру и пробелам
        [DataRow("Hello world", "hello", false)] // Проверка: метод чувствителен к регистру (H ≠ h)
        [DataRow("h e l l o", "hello", false)]   // Проверка: пробелы не считаются буквами
        [TestMethod()]
        public void GetRepeatedLetters_CaseSensitiveAndSpaces_ReturnsFalse(string input, string word, bool expectedResult)
        {
            // Act
            var actualResult = Zadanie.GetRepeatedLetters(input, word);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, "Метод чувствителен к регистру и пробелам");
        }

        // Тест проверяет граничные случаи с пустыми строками
        [DataRow("", "hello", false)]  // Проверка: пустая входная строка не содержит слово
        [DataRow("hello", "", true)]   // Проверка: пустое слово всегда содержится в любой строке
        [TestMethod()]
        public void GetRepeatedLetters_EmptyStrings_ReturnsExpected(string input, string word, bool expectedResult)
        {
            // Act
            var actualResult = Zadanie.GetRepeatedLetters(input, word);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, "Некорректная обработка пустых строк");
        }

        // Тест проверяет, что функция выбрасывает исключение при передаче null значений
        [DataRow(null, "hello")]   // Проверка: null входная строка
        [DataRow("hello", null)]   // Проверка: null искомое слово
        [ExpectedException(typeof(NullReferenceException))] // Ожидаем исключение NullReferenceException
        [TestMethod()]
        public void GetRepeatedLetters_NullParams_ThrowsException(string input, string word)
        {
            // Act - пытаемся вызвать функцию с null параметрами
            Zadanie.GetRepeatedLetters(input, word);

            // Если исключение не выброшено, тест провален
            // Эта строка выполнится только если исключение не было выброшено
            Assert.Fail("Не выброшено исключение для null параметров");
        }
    }
}