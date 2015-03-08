SpicyTaco.Maybe [![Build status](https://img.shields.io/teamcity/http/teamcity.krismcginnes.com:8084/s/SpicyTacoMaybe_Build.svg)](http://teamcity.krismcginnes.com:8084/viewType.html?buildTypeId=SpicyTacoMaybe_Build&guest=1) [![NuGet Prerelease Version](https://img.shields.io/nuget/vpre/SpicyTaco.Maybe.svg)](https://www.nuget.org/packages/SpicyTaco.Maybe/) [![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)](License.md)
===============

No one likes NullReferenceExceptions. Let's change things. Let consumers of your code know when a return value might be empty. Force them to acknowledge a possible lack of value.

My goal is to make `Maybe` as easy to use as possible, but also force the consuming code down the path of success. I'm doing this by not including _nice to have_ features such as implicit conversions, `.HasValue` or `.Value`, etc.

## Usage

When you're returning a value that might be null, follow this style:

```c#
public Maybe<Person> GetPersonByName(string firstName, string lastName)
{
  var person = _database.People
    .Where(x => x.FirstName == firstName && x.LastName == lastName)
    .FirstOrDefault()
    .ToMaybe();
  return person;
}
```

You're consumer will only be able to execute code on the value through accessor methods:

```c#
GetPersonByName("John", "Doe")
  .Do(person => SomeUsefulAction(person))
  .DoWhenEmpty(() => this.Log().Warn("No user named 'John Doe' could be found."));
```

## Install

You're welcome to install this library, but keep in mind it is a pre-release. I'm still plying with the API surface. Things might get renamed or dissapeared.

```
Install-Package SpicyTaco.Maybe -Pre
```

## License

I've licensed this under MIT License. That means do what you want with this code.
