SpicyTaco.Maybe
===============

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
