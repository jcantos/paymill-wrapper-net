Paymill#
========

Paymill# (*/paymill-sharp/*) allows easy consumption of the Paymill API.

Based on [Paymill Wrapper .NET](https://github.com/jcantos/paymillwrappernet).

Installation
------------

```
Install-Package PaymillSharp
```

Usage
-----
```cs
var paymill = new Paymill("apikey");
var payments = await paymill.Payments.GetAsync();
```

License
-------

MIT <a href="https://github.com/digitalcreations/paymillsharp/blob/master/LICENSE">License</a>