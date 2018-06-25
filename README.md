# Relay
This is a solution to recruitment task.

* Made in 3 evenings.
* With performace in mind - have simple benchmark for common scenario.

There are two channels:
* One is made with heavy emphasis on performance (BinaryChannel aka ISubscriber).
* One is made using different methods just to have somethign to talk about and measure other channel against (not optimized).

Could include some additionall stuff like IOC container or logger, but it seemed a bit excessive given the fact that this serves mearly as one step of recruitment process.

This includes unit tests, benchmark and small demo with couple of subscribers that write to console, simply to demonstrate that it works.

Tried not to assume too much. Aimed for a design that can be easly expanded and flexible enought to be improved if needed.

# Additional info:
When running benchmarks, use Release configuration.
