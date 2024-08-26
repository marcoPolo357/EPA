ASP.NET Web Application Development Project

As part of my academic project, I developed a web application that adhered to stringent structural and non-functional requirements. The project was implemented using a multilayered architecture, following the principles of object-oriented programming and SOLID design principles.

Key Features:

Architecture: I implemented a multilayered architecture with four distinct layers:
 - Data Layer: Managed data access and interaction with the relational database.
 - Business Logic Layer: Contained the core business rules and logic, ensuring data consistency and validation.
 - Service Layer: Facilitated communication between the business logic and presentation layers, exposing RESTful services.
 - Presentational Layer: Handled user interactions and displayed data to the users.

Object-Oriented Design: The application was developed with a focus on encapsulation, inheritance, and polymorphism, using method overloading. Each class adhered to the Single Responsibility Principle, and dependency injection was implemented through interface classes to promote flexibility and maintainability.

Data Handling: I designed a relational database with at least two interconnected tables, including a user table. Stored procedures, views, and transactions were used to ensure efficient data management and integrity. The application handled multiple queries within transactions using begin transaction and commit/rollback.

Parameterization: To enhance security and maintainability, the connection string and decision-making parameters were stored in external files, such as XML or JSON, rather than being hardcoded.

Clean Code and Security: The code was written following best practices for clean coding, including comprehensive comments, meaningful identifier names, and adherence to coding conventions. Security measures included password masking during login, session management, and user authentication checks on every page.

Localization: The user interface and code identifiers were fully localized in Serbian to meet the non-functional requirements.

This project provided me with hands-on experience in developing a robust, secure, and maintainable web application, reflecting industry standards and best practices.
