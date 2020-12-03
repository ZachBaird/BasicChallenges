using BasicChallenges.CaesarCipher;
using Xunit;

namespace BasicChallengeTests
{
    public sealed class CaesarCipherTests
    {
        [Fact]
        public void CorrectlyEncodesCaesarBy3()
        {
            var (message, encodeFactor) = ("Caesar", 3);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("Fdhvdu", result);
        }

        [Fact]
        public void CorrectlyEncodesHelloBy5()
        {
            var (message, encodeFactor) = ("Hello", 5);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("Mjqqt", result);
        }

        [Fact]
        public void CorrectlyEncodesWithNonLetters()
        {
            var (message, encodeFactor) = ("Hello, world!", 1);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("Ifmmp, xpsme!", result);
        }

        [Fact]
        public void CorrectlyEncodesZToA()
        {
            var (message, encodeFactor) = ("Z", 1);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("A", result);
        }

        [Fact]
        public void CorrectlyEncodesAToZ()
        {
            var (message, encodeFactor) = ("A", -1);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("Z", result);
        }

        [Fact]
        public void NumbersReturnUnaltered()
        {
            var (message, encodeFactor) = ("12345", 20);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal("12345", result);
        }

        [Fact]
        public void PunctuatioNReturnUnaltered()
        {
            var (message, encodeFactor) = (",.[]", -5);

            var result = CaesarCipher.Encode(message, encodeFactor);

            Assert.Equal(",.[]", result);
        }
    }
}
