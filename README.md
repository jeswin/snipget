# xnippet

Platform-agnostic Snippets Manager. Pronounced shni-pet.

The snippets are expected to be committed into your source control. xnippet tracks all downloaded snippets in xnippet.json. This file (xnippet.json) is also expected to be committed to your source control.

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

## Updating and Deleting Snippets

Update a specific snippet to the latest version.

```sh
# This gets the latest published version of the snippet
xnippet update @jeswin/router.js
```

Update all snippets in the current project. Based on xnippet.json

```sh
# This fetches all snippets found in xnippet.json
xnippet update --all
```

To delete a snippet, remove the file from your source code.
And delete the corresponding entry in xnippet.json.

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

Publish a file snippet. The current patch version is updated.

```sh
# Increments the patch version as well.
# eg: v1.4.4 -> v1.4.5. Or creates v0.0.1 if it's a new snippet.
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