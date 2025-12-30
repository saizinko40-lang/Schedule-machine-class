# Machine Class Scheduling System

This repository contains a coursework project developed as part of the Software Engineering discipline (Master’s program).

## Project Overview

The project represents a software prototype for automated scheduling of a computer classroom.  
The system generates a weekly schedule based on predefined requests while considering time constraints, group priorities, and the limited number of available computers.

The project focuses on demonstrating the application of software engineering principles rather than delivering a full-scale production system.

## Objectives

- Automate the process of creating a weekly schedule for a machine class
- Detect and resolve scheduling conflicts
- Apply priority-based decision-making for conflicting requests
- Demonstrate Test-Driven Development (TDD) and unit testing practices
- Illustrate iterative development using version control

## Functional Features

- Creation and processing of scheduling requests
- Validation of working hours (08:00–18:00)
- Validation of lesson duration (multiples of 90 minutes)
- Automatic detection of time conflicts
- Conflict resolution based on group priorities
- Limitation by the number of available computers
- Console-based demonstration of scheduling results

## Technologies Used

- Programming language: C#
- Platform: .NET
- Development environment: Visual Studio
- Unit testing framework: NUnit
- Version control system: Git
- Repository hosting: GitHub

## Project Structure

The solution follows a modular architecture with a clear separation of responsibilities.
Schedule/
├── Schedule.Core      # Core business logic and domain models
├── Schedule.Tests     # Unit tests implemented with NUnit
├── Schedule.Console   # Console application for demonstration purposes
- Schedule.Core contains the main business logic, including domain models, request validation, and the scheduling algorithm.
- Schedule.Tests includes unit tests that verify validation rules, conflict resolution, priority handling, and boundary cases.
- Schedule.Console is a simple console application used to demonstrate the results of the scheduling algorithm without interactive user input.

## Testing

The project follows the Test-Driven Development (TDD) approach.  
Unit tests are written before implementing business logic and cover:

- Request validation
- Boundary time conditions
- Conflict detection and resolution
- Priority-based scheduling behavior
- Limitation by the number of available computers

All tests can be executed via Visual Studio Test Explorer.

## Usage

The console application is intended for demonstration purposes only.  
User input is not required — scheduling requests are predefined to showcase the behavior of the system and the conflict resolution logic.

## Limitations

- No graphical user interface
- No persistent data storage
- Single machine class support

These limitations are intentional and correspond to the scope of the coursework.

## Future Improvements

Possible directions for further development include:
- Adding a graphical user interface
- Implementing data persistence (file or database storage)
- Supporting multiple machine classes
- Extending conflict resolution strategies
- Integrating with external educational systems

## Author

Sai Zin Ko  
Group 20130

## Course

Software Engineering  
Master’s Degree Program