# Introduction 

This project is an implementation of the `ILogger` facade that utilizes
`Microsoft.Extensions.Logging` to log. To satisfy an `Ilogger` dependency
using this adapter, simply new up an instance of
`MicrosoftExtensionsLoggingLogger` via any of the available constructors.

For example, you can create an instance using `LoggerFactory` via:

    var logger = new MicrosoftExtensionsLoggingLogger(loggerFactory, "Foo");

The second parameter, in this instance, becomes the `categoryName` utilized
by `Microsoft.Extensions.Logging` to distinguish log entries. However, it
far more common to use a particular type for this purpose, so a generic
version of `MicrosoftExtensionsLoggingLogger` is also provided:

    var logger = new MicrosoftExtensionsLoggingLogger<MyType>(loggerFactory);

For an example of integrating this into an ASP.NET Core application, see
the `Mfah.Logging.Samples.AspNetCoreWebApp` sample project.

# Contribute

Contributions are welcome and appreciated. Simply fork this project on Github
and then submit a pull request with your changes. After being reviewed, pull
requests will be merged when they add demonstrable value. Minor changes that
do not add demonstrable value, will likely be rejected. You should consider
submitting an issue, instead, if you feel like something should be changed
which does not add great improvement to the functionality of the library,
explaining *in detail* what benefit you believe such a changes adds.