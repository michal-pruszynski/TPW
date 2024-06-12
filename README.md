# Concurrent programming

## Working Group

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| MP                      | `01e159af-4124-4c3e-bcdf-50dd80c893b9`   |
| MS                      | `e7e52d02-af97-4a39-8b51-0a6180b22eaa` |

## Create a repository checklist
ETAP - 3
- [X] **Starting point**
  - [X] text is in C#
  - [X] all UT are green
  - [X] the program behaves as expected (intermediate approval test)
- [X] **Data Layer**
  - [X] responsibility of this layer is
    - [X] to represent boundaries of the movement rectangle if necessary
    - [X] implement balls behavior as self-contained independent entities
    - [X] save diagnostic data to a file
  - [X] protect balls velocity against any influence from other balls and the environmental behavior
  - [X] balls implementation uses concurrent programming
  - [X] prove that the diagnostic logging doesn't have an impact on the behavior of the balls
- [X] **Logic Layer**
  - [X] responsibility of this layer is to manage movement rectangle boundaries and balls interaction (collisions)
  - [X] prove that the protection of data (balls position on the abstract table during collisions detection) integration is implemented
  - [X] `Logic` uses only the abstract `Data` layer API
- [X] **Presentation Layer (MVVM)**
  - [X] responsibility of this layer is to manage the graphical user interface (GUI)
  - [X] user => GUI interoperability must be implemented using interactive programming only
  - [X] GUI => the user interoperability must be implemented using reactive programming only (timer is not allowed)
  - [X] interoperability of the GUI and underlying layers must be synchronized
  - [X] prove that the protection of data (balls position on the screen) integration is implemented
- [X] **Testing**
  - [X] Unit Test - layers are tested independently using dependency injection (additional framework is not required)
  - [X] Mock may be used for testing purposes (expected but not required)

ETAP - 2
- [X] **Starting point**
  - [X] text is in C#
  - [X] all UT are green
  - [X] the program behaves as expected (intermediate approval test)
- [X] **Data Layer**
  - [X] responsibility of this layer is to represent boundaries of the movement rectangle and balls
  - [X] balls representation are independent and self-contained (no timer required)
  - [X] balls implementation uses concurrent programming
- [X] **Logic Layer**
  - [X] responsibility of this layer is to manage movement rectangle boundaries and balls interaction (collisions)
  - [X] prove that the protection  of data integration is implemented
  - [X] `Logic` uses only the abstract `Data` layer API
- [X] **Presentation Layer (MVVM)**
  - [X] responsibility of this layer is to manage the graphical user interface (GUI)
  - [X] user => GUI interoperability must be implemented using interactive programming only
  - [X] GUI => the user interoperability must be implemented using reactive programming only (timer is not allowed)
  - [X] interoperability of the GUI and underlying layers must be synchronized
- [X] Fulfill functional requirements of the task
- [X] **Testing**
  - [X] Unit Test - layers are tested independently using dependency injection (additional framework is not required)
  - [ ] Mock may be used for testing purposes (expected but not required)


ETAP - 1
- [X] text is in C#
- [X] build succeeded
- [X] all UT are green
- [X] `Data` layer is clearly stated using language terms only (no database, no file)
- [X] `Data` API is clearly stated
- [X] `Data` API is abstract
- [X] `Logic` layer is clearly stated using language terms only
- [X] `Logic` API is clearly stated
- [X] `Logic` uses only the abstract `Data` layer API
- [X] `Presentation` layer is clearly stated using language terms only
- [X] `Presentation` uses only the abstract `Logic` layer API
- [X] MVVM and XAMLare applied to implement GUI
- [X] reactive and interactive user interaction for user (operator) communication
- [X] reactive and interactive programming is used for the communication of layers 
- [X] `Presentation` - object model representing process data
- [X] Fulfill functional requirements of the task
- [X] Unit Test - layers are tested independently using abstract API
- [X] Dependency injection (additional framework is not required)
- [X] Mock is used for testing purposes (expected but not required)

ETAP - 0
- [X] the task provides required feedback and has been submitted (needs grading)
- [X] the ability to clone the repository to the teacher's computer
- [X] there is README.md formatted as expected
- [X] `README.md` contains required information
- [X] build succeeded
- [X] all UTs are green
