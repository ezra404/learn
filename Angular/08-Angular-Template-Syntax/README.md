# Angular Template Syntax and Data Binding

## Understanding Interpolation

To get us started, let's understand a bit about interpolation. Interpolation is just the process of putting expressions into our HTML that Angular will then evaluate and convert into HTML when it's rendered.

For example: 

```html
<h1>2 + 2 =</h1>
<bot-catalog />
```

Will render exactly 2 + 2 = in the browser. Why? Because this is just regular HTML.

Now if we add these double curly braces: 

```html
<h1>2 + 2 = {{ 2 + 2}}</h1>
<bot-catalog />
```
The expression inside the {{}} will evaulate to 4 and inserted in the HTML to be rendered.

But this is reserved for basic JavaScript expressions.

If we try to wrap this in something like Math.round, we will get an error. Angular intentionally limits what you can do in interpolation expressions in order to keep us from putting lots of JavaScript code in our HTML templates, that code should instead reside in the Component class.


## Data Binding with interpolation

Adding data binding will let us stop hardcoding our product data in our HTML template.

For a template to access a component's property, the property needs to be public. 

Sidebar: TypeScript properties are public by default, no need to specify a public accessor keyword. Private properties are specified with the 'private' keyword.

Example, if we have the following product property in our component class:

```typescript

@Component({
  selector: 'bot-product-details',
  imports: [CurrencyPipe],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

  product: IProduct;

  constructor() {
    this.product = {
      id: 2,
      description: 'A friendly robot head with two eyes and a smile -- great for domestic use.',
      name: 'Friendly Bot',
      imageName: 'head-friendly.png',
      category: 'Heads',
      price: 945.0,
      discount: 0.2
    }
  }

}

```

You can access the `product` property from inside the template using an interpolation expression, aka the double braces {{}}.

```htmlangular

<div class="product">
  <img src="{{ '/images/robot-parts/' + product.imageName }}">
  <div class="details"></div>
  <div>
    <h2>{{ product.name }}</h2>
    <p>{{ product.description}}</p>
    <p>Part Type: {{product.category}}</p>
  </div>
  <div class="price">
    <p>{{product.price | currency }}</p>
    <button class="cta">Buy</button>
  </div>
</div>

```

The funny looking " | currency " bit is called a Pipe. Which is a way to transform data in a
template expression i.e formatting things to look a certain way. Similar to how it's done in Hugo.

## Attribute Binding

Let's take a look at attribute bindings, which are another way to bind to data in the component class.

We'd like the alt attribute to be set to the name of the product. But how do we do that? We could
just say alt = "{{ product.name }}".

But, we can actually use an attribute binding to do this instead of an interpolation expression. To
do that, we wrap the attribute we want to bind with square brackets []: 

Now it expects this attribute value to be set to a JavaScript expression. 

> [!NOTE]
> Interpolation expressions evaluate to strings, hence they are not really helpful for other data
> types like booleans and objects we might want to bind to a property, since a property
> binding binds to an expression and uses the result as is (preserves the original type). 

```htmlangular

<div class="product">
  <img src="'/images/robot-parts/' + product.imageName" [alt]="product.name">
  <div class="details"></div>
  <div>
    <h2>{{ product.name }}</h2>
    <p>{{ product.description}}</p>
    <p>Part Type: {{product.category}}</p>
  </div>
  <div class="price">
    <p>{{product.price | currency }}</p>
    <button class="cta">Buy</button>
  </div>
</div>

```

Rule of thumb:

- Use interpolation when you want to render a string of text inside a heading, paragraph, or span (e.g., `<h1>Hello {{ name }}</h1>`).

- Use property binding whenever you are setting a property of an HTML element or passing data down to a child component (e.g., `<app-user-profile [user]="currentUser">`).

### Direction of the binding

The direction of the binding with property attributes is One Way, data flows from the component
class to the HTML attribute.

```htmlangular
<input type="text" [value]="product.name" />

```

If the data changed in the component, it would change the value of the input box in the browser. 
But if the user changed the value of the input box by typing something into the input box, it would not
actually change the value in the Component class.

#### Note on two-way data binding:

It's a ruseeeeee. It's fake. Well, in the modern sense. It used to be that two-way data binding
meant if the input / ui changed the data, it would also update the component's data. Which may
cause a flurry of updates in your other components. A big who done it situation.

Now, modern frameworks have wisened up. Instead of two-way, it's still one way data binding
(unidirectional), but if you want the input to change the data in the component, you have to be
explicit and pass in an event handler to do so. But it would be tedious for a developer to
pass an event handler each time they wanted to update a component's value from the UI. So the
smart framework authors thought to give us syntactic sugar in the likes of `[(ngModel)]`
in Angular or `v-model` in Vue to denote that a property is being set, and also it's event handler
is being wired automatically.

So the wiring matters because

If you've ever dealt with a complex form—say, one where an "Age" input needs to be restricted to numbers only—this architectural distinction becomes your best friend.

In a "Literal" Two-Way System: The moment the user types "ABC" into the box, your variable is corrupted. It's already "ABC" in your code before you can even blink.

In the "Wiring" System: The user types "ABC," the input fires an event. Your component catches it, sees it's not a number, and says, "No thanks." The variable stays a number, and the UI is told to revert the text box to the last valid state.

The "Source of Truth"

In the engineering world, we call this Single Source of Truth (SSOT). When you use property binding [value] and event binding (input), you are ensuring that:

The Component State is the only place the data "lives."

The DOM (the input box) is just a visual representation of that state.

Moral of the story: instead of writing `[value]="name" (input)="name = $event"`,  because it’s so common, frameworks gave us the syntax sugar (v-model or [(ngModel)]) to do that wiring for us.


### Calling functions from a component template

We can actually bind HTML attributes to functions, or perhaps more accurately, bind them to the return value of a function, this is helpful when you want to do something more complex or execute some logic that isn't supported by an inline template expression.

E.g

```typescript

@Component({
  selector: 'bot-product-details',
  imports: [CurrencyPipe],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

    // ... product definition above

    getImageUrl() {
       return '/images/robot-parts/' + product.imageName
    }
}

```

```htmlangular

<div class="product">
  <img src="getImageUrl()" [alt]="product.name">
  <div class="details"></div>
  <div>
    <h2>{{ product.name }}</h2>
    <p>{{ product.description}}</p>
    <p>Part Type: {{product.category}}</p>
  </div>
  <div class="price">
    <p>{{product.price | currency }}</p>
    <button class="cta">Buy</button>
  </div>
</div>

```

### Note on performance

Change Detection

This is where developers often get into trouble. Angular’s Change Detection cycle is very aggressive. To ensure the UI is always up to date, Angular re-renders the view whenever anything happens (a click, a timer, an API call).

When you bind to a function like [src]="getAvatar()":

    Angular asks: "Has the data changed?"

    To find out, it must run the function getAvatar().

    It compares the new result with the old result.

    It does this every single time a change detection cycle runs.

If that function contains a loop, a complex calculation, or a console.log, you will see that code executing dozens (or hundreds) of times per minute. This can lead to massive performance lag.
A good mental shortcut for Angular development is:

If you see [], try to put a variable inside. If you see (), put a function inside.

[property]="variable": "Hey Angular, here is the data. Just hold onto it."

(event)="function()": "Hey Angular, something happened! Go run this logic."

By keeping logic inside the () and raw data inside the [], you are working with the framework's optimization engine instead of fighting against it.
Exceptions to the Rule

There is one common place where you do use a function in a binding: Event Emitters.
When a child component says (change)="onUserChange($event)", you are using a function because that only runs once—exactly when the user actually changes something. That isn't a performance risk because it's not part of the "render loop"; it's a response to a specific action.

## Responding to User Events

In addition to binding to data, we can also bind to user events, like button clicks for example, so that we can execute a function whenever that event occurs.

In Angular, you handle user events by binding to them directly in your components template using parentheses.

Example:

```htmlangular
    <button class="cta" (click)="addToCart()"></button>
```

And now, whenever a user clicks on this button, it will call the addToCart method on our Component class.

The event name inside the parentheses can be any of your standard DOM events i.e keyup, change,
mousedown etc

You pass in event information to methods as an argument using `$event`. And the method should
make sure to set an event parameter, either a generic one like Event or a specific one like
MouseEvent / PointerEvent.
