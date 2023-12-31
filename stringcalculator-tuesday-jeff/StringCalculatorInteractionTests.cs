﻿namespace StringCalculator;
public class StringCalculatorInterationTests
{
    private readonly StringCalculator _calculator;
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculatorInterationTests()
    {
        _logger = Substitute.For<ILogger>();
        _webService = Substitute.For<IWebService>();
        _calculator = new StringCalculator(_logger, _webService);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("1,3")]
    public void WritesToLogger(string numbers)
    {
        var result = _calculator.Add(numbers);

        _logger.Received().Write(result.ToString());
        _webService.DidNotReceive().NotifyOfLoggingFailure();

    }

    [Fact]
    public void SendsMessageToApiIfLoggerFails()
    {
        _logger.When(m => m.Write("999"))
            .Do(x => throw new LoggingException());
        //_logger.When(b => b.Write("999")).Throws<LoggingException>();
        _calculator.Add("999");

        _webService.Received(1).NotifyOfLoggingFailure();

    }
}