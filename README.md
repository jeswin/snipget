# snipget

Platform-agnostic Snippets Manager.

The snippets are expected to be committed into your source control. snipget tracks all downloaded snippets in snipget.json. This file (snipget.json) is also expected to be committed to your source control.

## Installation

Download binaries for your system. Currently only 64-bit Linux, OSX and Windows platforms are supported. 

Links:
- [Linux](https://snipget.com/download/linux)
- [Mac OS](https://snipget.com/download/osx)
- [Windows](https://snipget.com/download/windows)

## Downloading snippets

```sh
# Adds the latest version of this snippet.
snipget add @jeswin/router.js
```

Add a specific version of the snippet

```sh
# Adds a specific version. Error if not found.
snipget add @jeswin/router.js@1.3.4
```

Add the latest snippet for a fixed major/minor version

```sh
# Get the latest snippet conforming to major version 2.
# Maybe v2.4.1
snipget add @jeswin/router@2

# Get the latest snippet conforming to major version 2, minor version 3.
# Maybe v2.3.6
snipget add @jeswin/router@2.3
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
# Deletes all sessions (from all machines) for this user. You need to be online.
snipget logout --all
```

Change username. The existing username now becomes available for other people to claim. Use this feature with caution, since many links will get orphaned.

```sh
# Rename the logged in user.
# snipget rename <current_username> <new_username>
snipget rename alice alicia
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

Get versions of a snippet.

```sh
# Lists all available versions of the snippet.
snipget versions router.js
```

Delete a version of a snippet. If it was the latest, the previous version becomes current.

```sh
# Delete the version 1.4.0.
snipget rm router.js@1.4.0
```

Delete all versions of a snippet. Use caution.

```sh
# Delete a file
snipget rm router.js --all

# Or maybe a directory
snipget rm easy-router --all
```

# Teams

You can create a team and add more people to it. You'll be the admin. Both admins and normal users can publish snippets, but only admins can add other users.

Creating a Team.

```sh
# Create a team called foodevs
snipget team foodevs
```

You can add other admins and normal users.

```sh
# Add alice as admin
snipet team foodevs --admin alice

# Add bob as a normal user
snipget team foodevs --user bob
```

Or remove them. You cannot remove yourself, but another admin can.

```sh
# Remove alice as admin
snipet team foodevs --rm alice
```

All published snippets live under the team's namespace.

```sh
# Download snippets from the team 'foodevs'
snipget add @foodevs/router.js
```

# Publishing in Teams

Publishing team snippets is very similar to what we saw earlier, you'd just need to specify the 'team' option. All the other commands work as well.

```sh
# Publishing a snippet
snipget pub router.js --team foodevs
```

```sh
# Removing
snipet rm router.js --team foodevs
```

# Private Snippets

You need to first create a key pair to create and download Private Snippets.
The keys are stored under the .snipget directory within your home directory. The default key is named 'default'.

```sh
snipget key
```

You can create multiple keys with the 'key' command.

```sh
snipget key myworkkey
```

You can print a public key with the 'pubkey' command.

```sh
# Print the default key
snipget pubkey

# Print a named key
snipget pubkey myworkkey
```

Delete keys with the 'rm' option.

```sh
snipget key myworkkey --rm
```

Now to add a new private snippet, add a 'key' option to the add command. This encrypts the snippet with your default key. Once a snippet has been add as an encrypted file, it cannot be updated an an unencrypted file; you'll have to remove the snippet and start afresh.

```sh
snipget add router.js --key
```

You can use a different key, if you wish.

```sh
snipget add router.js --key myworkkey
```

