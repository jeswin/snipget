# xnippet

Snippets Manager. Pronounced shnee-pet.

Add a file snippet from the user 'jeswin' to the current project.
This also creates an xnippet.json file to track the snippet versions.

## Downloading snippets

```sh
# Gets the latest version of this snippet.
xnippet add @jeswin/router.js
```

Add a specific version of the snippet

```sh
# Gets a specific version. Error if not found.
xnippet add @jeswin/router.js@1.3.4
```

Add to a specific location.

```sh
# Saves the snippet in a specific directory. Creates dir if missing.
xnippet add @jeswin/router.js vendor/utils/
```

Download without creating xnippet.json or adding to it.

```sh
# This just downloads the file. Version is not maintained.
xnippet get @jeswin/router.js vendor/utils/
```

## Publishing

Login to xnippet. Only required if you're publishing snippets.

```sh
# Login. Will be asked to create an account if it doesn't exist.
xnippet login
```

Who am I?

```sh
# Returns the logged in username
xnippet whoami
```

Logout

```sh
# Deletes the session cookie. You'll need to login now to publish.
xnippet logout
```

Publish a file snippet. Assigns the smallest version 0.0.1 if new. If the snippet already exists, the current patch version is updated.

```sh
# Increments the patch version as well.
# eg: v1.4.4 -> v1.4.5. Or creates v0.0.1 if new.
xnippet pub router.js
```

Publish and update the minor version.

```sh
# Increments the minor version, and sets the patch version to zero.
# eg: v1.4.4 -> v1.5.0
xnippet pub router.js --minor
```

Publish and update the major version.

```sh
# Increments the major version, and sets others to zero.
# eg: v0.4.0 -> v1.0.0
xnippet pub router.js --major
```

Publish a directory. 

```sh
xnippet pub easy-router/

# Add will download the directory.
xnippet add @jeswin/easy-router

# Saves into vendor/easy-router
xnippet add @jeswin/easy-router vendor/
```

Delete a snippet.

```sh
# Delete a file
xnippet del router.js

# Or maybe a directory
xnippet del easy-router
```