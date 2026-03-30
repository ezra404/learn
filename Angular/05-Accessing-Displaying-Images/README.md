# Accessing and Displaying Images

The standard way for storing and accessing images in an Angular project is to place them in the
`public/` directory.

When Angular builds the application, contents inside the `public/` directory are copied as-is to the
root directory of the build output.

Since images (or other resources) in the `public/` directory are deployed to the root directory of
your web build, you can access them using "/images/your-lovely-image.webp" for example. You don't
have to specify the 'public' part.
