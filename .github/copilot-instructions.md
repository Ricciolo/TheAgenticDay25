./../copilot-instructions.md
````````

This is the description of what the code block changes:
Aggiunge una nuova sezione "JSON Models" con la regola di utilizzare JsonElement invece di object per i modelli che rappresentano JSON.

This is the code block that represents the suggested code change:

````````markdown
## Technology Stack
- **.NET 10** with C# 14

## C# 14 Code Style

### EditorConfig Compliance
**MANDATORY**: follow the styles defined in `.editorconfig`. The main rules are:

**Naming Conventions:**
- Classes, methods, public properties: **PascalCase**
- Parameters and local variables: **camelCase**
- Private fields: **camelCase with `_` prefix** (e.g., `_logger`)
- Static fields: **camelCase with `s_` prefix** (e.g., `s_instanceCount`)
- Constants: **PascalCase**

**Formatting:**
- Indentation: **4 spaces** for C# files
- Always use `var` for local variables when the type is apparent
- Braces: mandatory even for single-line statements
- No spaces after cast, before commas, after parentheses

**Expression Bodies:**
- Properties/indexer: **always expression-body** (`public int Value => _value;`)
- Methods/constructors: **never expression-body** (use blocks `{ }`)

### Mandatory Patterns
- **Nullable reference types** enabled (`<Nullable>enable</Nullable>`)
- **Primary constructors** for classes and records
- **Required properties** with `required` keyword where appropriate
- **File-scoped namespaces** to reduce indentation
- **Target-typed new** expressions where possible
- **Modern pattern matching** (switch expressions, property patterns)

### Async Methods
- **`Async` suffix** mandatory for all async methods
- **`CancellationToken`** as last parameter to support cancellation
- Always pass the token to internal async operations

### Comments
- **XML comments (`///`)** only for public members (classes, methods, public properties) and must be in Italian
- **NO XML comments** for private methods/members
- **NO emoji** in comments
- Internal comments and documentation must be in Italian
- **Inline comments**: briefly comment each non-obvious step in the code to clarify complex logic

### Logging and Exceptions
- Use **ILogger** to trace operations and execution flow
- All log messages and exception messages (including errors exposed externally) must be strictly in English

### JSON Models
- **MANDATORY**: use `JsonElement` instead of `object` for properties representing JSON data
- This ensures type safety and proper serialization/deserialization of JSON structures

### Refit API Interfaces
- **Header parameters** (especially optional ones like `x-ms-client-request-id`): do NOT expose them as method parameters
- Optional headers should be managed via **HttpClientHandler**, **middleware**, or **DelegatingHandler** to avoid cluttering method signatures
- Keep Refit interface signatures clean and focused on core functionality
- Maintain separation of concerns: API calls vs. cross-cutting concerns (like request tracking)