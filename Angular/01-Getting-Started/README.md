# Getting Started

Angular core architectural idea is centered around "Components".

## Components

Components are considered the building blocks of an Angular application, which
make it easy to structure your app into clear, reusable pieces.

**What is a component exactly?** 

Each component controls a section of the user interface and combines **3 things:** 

1. A TypeScript class to control the components' data and behaviour
2. An HTML template to define what appears on the screen
3. CSS styles to create a polished UI

The class and HTML template work together so that when data changes in the class, the template
updates the UI automatically.

### HTML Templates

They use an HTML-like declarative syntax that connects your app's data to the user interface

Example

```htmlangular
<ul>
    @for (product of products; track product.id) {
        <li class="product" (onclick)="addToCart()">
            {{ product.name }}
        <li>
    }
</ul>
```

They also use fancy syntax for binding data, user interactions and events, and structuring the html
through conditionals and repetitition.

**NOTE** since i am coming form dinosaur angular v7, modern Angular uses what's called "standalone"
components. Meaning they can import whatever they need (dependencies) without being bundled in a module. 

## Services

Another core building block of an Angular application. 

Services are basically TypeScript classes that expose reusable functionality such as data access,
state management, or other reusable business logic.

Unlike Components, they do not contain a UI element. They're all about logic and state management.


## Dependency Injection

The preferred mechanism for Angular to "inject" services and other dependencies into components that
require them during runtime. This helps you write decoupled, scalable and testable code.


## Routing

A mechanism to navigate to a particular URL, where certain Components will be rendered. Angular
provides a "Router" to help you organise your components into navigable views and pages. It also
controls how and when components are rendered to improve performance.

## Change Detection and Reactivity

Angular uses a system to track and sync the user interface and data as data changes throughout the
app's lifecyle and use. Angular handles a vast majority of this "change detection" automatically.
Modern Angular uses a concept called "signals" which provides a powerful way to declare reactive
state, letting Angular know, efficiently, when to update the screen, compared to the ol' Zone.js
we're used to in Angular 7.
