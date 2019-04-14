# xnippet

Snippets Manager. Pronounced shnee-pet.

Add a file snippet from the user 'jeswin' to the current project.
This also creates an xnippet.json file to track the snippet versions.

## Downloading snippets

```sh
xnippet add @jeswin/router.js
```

Add a specific version of the snippet

```sh
xnippet add @jeswin/router.js@1.3.4
```

Add to a specific location.

```sh
xnippet add @jeswin/router.js vendor/utils/
```

Download without creating xnippet.json or adding to it.

```sh
xnippet get @jeswin/router.js vendor/utils/
```

## Publishing

Login to xnippet. Only required if you're publishing snippets.

```sh
xnippet login
```

Who am I?

```sh
xnippet whoami
```

Logout

```sh
xnippet logout
```

Publish a file snippet. Assigns the smallest version 0.0.1 if new. If the snippet already exists, the current patch version is updated.

```sh
xnippet pub router.js
```

Publish and update the minor version.

```sh
xnippet pub router.js --minor
```

Publish and update the major version.

```sh
xnippet pub router.js --major
```

Publish a directory. 

```sh
xnippet pub easy-router/

# Add will download the directory.
xnippet add easy-router
```
