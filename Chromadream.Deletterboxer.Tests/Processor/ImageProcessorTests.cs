using System;
using System.IO;
using Xunit;
using TestStack.BDDfy;
using Shouldly;
using Chromadream.Deletterboxer.Impl.Processor;

namespace Chromadream.Deletterboxer.Tests.Processor
{
    public class ImageProcessorTests
    {
        private string _fileName;
        private int _actualLetterbox;
        private Exception _exception;

        [Fact]
        public void GetsTheHeightOfLetterbox()
        {
            this.Given(x => GivenAReferenceToFileWithLetterbox())
                .When(x => WhenLetterboxHeightIsRequested())
                .Then(x => ThenThereShouldBeNoException())
                .And(x => ThenItShouldReturnLetterboxHeight())
                .BDDfy();
        }


        private void GivenAReferenceToFileWithLetterbox()
        {
            _fileName = Path.Join("Assets", "testfile.jpg");
        }

        private void WhenLetterboxHeightIsRequested()
        {
            _exception = Record.Exception(() => _actualLetterbox = ImageProcessor.GetLetterboxHeight(_fileName.ToString()));
        }

        private void ThenThereShouldBeNoException()
        {
            _exception.ShouldBeNull();
        }

        private void ThenItShouldReturnLetterboxHeight()
        {
            _actualLetterbox.ShouldBeGreaterThan(1);
            _actualLetterbox.ShouldBeLessThan(36);
        }
    }
}
