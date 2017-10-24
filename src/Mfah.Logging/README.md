# Introduction 

This project contains the logging facade used internally for MFAH projects, but
anyone is welcome use or expand on this code. Projects open-sourced by the MFAH
will depend on this facade, so you will need to also use it any projects based
on those. Simplistically, you will just need to inject some implementation of
the `ILogger` interface into class constructors that accept it to enable logging
from those classes.

There are two built-in implementations: `DebugLogger` and `TraceLogger`, which
log to `System.Diagnostics.Debug` and `System.Diagnostics.Trace`, respectively.
`DebugLogger` will often be used as the default logger, when no more specific
implementation is passed, as it satisfies the dependency and only logs when
debugging.

Creating additional logging adapters is easy, requiring implementation of the
sole method on `ILogger`: `Log(LogEntry)`. Extensions to the `ILogger` interface
exist to provide additional syntactic sugar methods such as `Debug(string)`,
`Error(Exception)`, etc. If you happen to be dealing with a concrete `ILogger`
implementation directly, you can simply cast to `ILogger` to access these
extensions. For the most part, you should only be directly working with
`ILogger`, though.

# Usage

Ideally, you should inject `ILogger` into classes that need to log.

    public class MyAwesomeClass
    {
        protected readonly ILogger _logger;

        public MyAwesomeClass(ILogger logger)
        {
            _logger = logger;
        }
    }

In configuring your DI container, or when manually injecting, you would simply
provide an instance of an implementation of `ILogger` you wish to use. For
example:

    var logger = new DebugLogger();
    var myAwesomeObject = new MyAwesomeClass(logger);

Additional `ILogger` implementations are available as NuGet packages. Those
provided by the MFAH will follow the naming convention of:
`Mfah.Logging.{Implementation}`.


# Contribute

Contributions are welcome and appreciated. Simply fork this project on Github
and then submit a pull request with your changes. After being reviewed, pull
requests will be merged when they add demonstrable value. Minor changes that
do not add demonstrable value, will likely be rejected. You should consider
submitting an issue, instead, if you feel like something should be changed
which does not add great improvement to the functionality of the library,
explaining *in detail* what benefit you believe such a changes adds.

For contributing additional adapters, you may choose to either contribute
them to this project or use a separate repository of your own. Either
way, you must comport with the terms of the MIT License.

