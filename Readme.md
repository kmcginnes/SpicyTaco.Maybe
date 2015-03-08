SpicyTaco.Maybe
===============

<a href="http://teamcity.krismcginnes.com:8084/viewType.html?buildTypeId=SpicyTacoMaybe_Build&guest=1">
<img src="https://img.shields.io/teamcity/http/teamcity.krismcginnes.com:8084/s/SpicyTacoMaybe_Build.svg"/>
</a>

No one likes NullReferenceExceptions. Let's change things. Let consumers of your code know when a return value might be empty. Force them to acknowledge a possible lack of value.

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
