## Why write automated tests

- Free to run as often as required
- Run at any time, on-demand or scheduled
- Quicker to execute than manual testing
- Find errors sooner
- Generally reliable
- Test code sits with production code
- Happier development teams

## Types of Automated Tests

- Unit Tests
- Integration Testing
- Subcutaneous
- UI testing

### Testing Behaviour vs. Private Methods

### The Logical Phases of an Automated Test

- Arrange - set things up, create object instances, create test data/inputs
- Act - Execute production code, call methods, set properties
- Assert - Check results. Test passes/fails

### Asserts

Asserts evaluate and verify the outcome of a test, based on a returned result, final object state, or the occurrence of events observed during execution. An assert can either pass or fail. If all asserts pass, the test passes; if any assert fails the test fails.

#### Boolean values

- True/false

#### String values

- Equality, inequality
- Empty
- Starts with / ends with
- Contains substring
- Matches regular expression

#### Numeric values

- Equality, inequality
- In a given range
- Floating point precision

#### Collection contents

- Equality with another collection
- Contains/does not contain
- Contains item satisfying predicate

#### Raised events

- Custom events
- Framework events

#### Object types

### How Many Asserts per Test?

### Test Data Sources

- Inline attribute
- Property/field/method
- Custom attribute
- External data

## Mocking

Mocking is replacing the actual dependency that would be used at production time, with a test-time-only version to enable easier isolation of the code we want to test.

### Reasons you might want to use Mocks

- Improved test execution speed e.g due to slow algorithms, external resources
- Support parallel development streams e.g real object not yet developed
- Improve test reliability
- Reduce development/testing costs e.g external company bills per usage,developer effort, interfacing with mainframe
- Test when non-deterministic dependency

### Terms

- **Test Double** - a generic term for any case where you replace a production object for testing purposes.
- **Fakes** - Working implementation. Not suitable for production
- **Dummies** - Passed around. Never used/accessed. To satisfy parameters
- **Stubs** - Provide answers to calls. Property gets,.Method return values
- **Mocks** - Expect/verify calls


