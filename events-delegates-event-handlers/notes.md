# Events, Delegates and Event Handlers

Events enable a class or object to notify other classes or objects when something of interest occurs. The class that sends (or raised) the event is called the publisher and the class that receives (or handles) the event are called subscribers.

In a typical C# Windows Forms or Web application, you subscribe to events raised by controls such as buttons and list boxes.

Events have the following properties:

- The publisher determines when an event is raised; the subscribers determine what action is taken in response to the event.
- An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers
- Events that have no subscribers are never raised.
- Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces
- When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised.
- In .NET Framework class library, events are based on the `EventHandler` delegate and the `EventArgs` base class.

Events are notification.

## Role of Events

- Events signal the occurrence if an action/notification
- Objects that raise events don't need to explicitly know the object that will handle the event.
- Events pass data with `EventArgs`

## The Role of Delegates

A delegate is a specialized class often called a "Function Pointer". Based in a MulticastDelegate base class.

## Event Handlers

Event handler is responsible for receiving and processing data from a delegate. Normally receives two parameters

- Sender
- EventArgs

EventArgs are responsible for encapsulating event data. An event handler is responsible for accessing data passed by a delegate.