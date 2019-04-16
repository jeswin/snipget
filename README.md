# snipget

Platform-agnostic Snippets Manager. Pronounced shni-pet.

The snippets are expected to be committed into your source control. snipget tracks all downloaded snippets in snipget.json. This file (snipget.json) is also expected to be committed to your source control.

## Installation

Download binaries for your system. Currently only 64-bit Linux, OSX and Windows platforms are supported. 

Links:
- [Linux](https://snipget.com/download/linux)
- [Mac OS](https://snipget.com/download/osx)
- [Windows](https://snipget.com/download/windows)

## Downloading snippets

```sh
# Gets the latest version of this snippet.
snipget add @jeswin/router.js
```

Add a specific version of the snippet

```sh
# Gets a specific version. Error if not found.
snipget add @jeswin/router.js@1.3.4
```

Add to a specific location.

```sh
# Saves the snippet in a specific directory. Creates dir if missing.
snipget add @jeswin/router.js vendor/utils/
```

Download without creating snipget.json or adding to it.

```sh
# This just downloads the file. Version is not maintained.
snipget get @jeswin/router.js vendor/utils/
```

## Updating and Deleting Snippets

Update a specific snippet to the latest version.

```sh
# This gets the latest published version of the snippet
snipget update @jeswin/router.js
```

Update all snippets in the current project. Based on snipget.json

```sh
# This fetches all snippets found in snipget.json
snipget update --all
```

To delete a snippet, remove the file from your source code.
And delete the corresponding entry in snipget.json.

## Publishing

Create an account. Required only if you're publishing snippets.

```sh
# You will be asked for password. snipget signup [username]
snipget signup kai
```

Login to snipget. 

```sh
# Login. Will be asked to create an account if it doesn't exist.
snipget login
```

Who am I?

```sh
# Returns the logged in username
snipget whoami
```

Logout

```sh
# Deletes the session cookie. You'll need to login now to publish.
snipget logout
```

Logout of all sessions on all machines.

```sh
# Deletes all sessions from the server for this user. You need to be online.
snipget logout --all
```

Publish a file snippet. The current patch version is updated.

```sh
# Increments the patch version as well.
# eg: v1.4.4 -> v1.4.5. Or creates v0.0.1 if it's a new snippet.
snipget pub router.js
```

Publish and update the minor version.

```sh
# Increments the minor version, and sets the patch version to zero.
# eg: v1.4.4 -> v1.5.0
snipget pub router.js --minor
```

Publish and update the major version.

```sh
# Increments the major version, and sets others to zero.
# eg: v0.4.0 -> v1.0.0
snipget pub router.js --major
```

Publish a directory. 

```sh
snipget pub easy-router/

# Add will download the directory.
snipget add @jeswin/easy-router

# Saves into vendor/easy-router
snipget add @jeswin/easy-router vendor/
```

Delete a snippet.

```sh
# Delete a file
snipget del router.js

# Or maybe a directory
snipget del easy-router
```