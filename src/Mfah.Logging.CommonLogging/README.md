# Introduction 

This project is an implementation of the `ILogger` facade that utilizes
`Common.Logging` to log. To satisfy an `Ilogger` dependency
using this adapter, simply new up an instance of
`CommonLoggingLogger`.

For example, you can create an instance using `LogManager` via:

    var logger = new CommonLoggingLogger(LogManager.GetLogger<MyType>());


# Contribute

Contributions are welcome and appreciated. Simply fork this project on Github
and then submit a pull request with your changes. After being reviewed, pull
requests will be merged when they add demonstrable value. Minor changes that
do not add demonstrable value, will likely be rejected. You should consider
submitting an issue, instead, if you feel like something should be changed
which does not add great improvement to the functionality of the library,
explaining *in detail* what benefit you believe such a changes adds.