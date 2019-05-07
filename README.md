# snipget

Platform-agnostic Snippets Manager. 

## Why?

- Package management approaches (such as npm) result in 100s of MBs of downloads
- Sometimes all you need is a single file which you could commit to your version control.
- Semver ranges are a security risk. The next patch version could be malicious.
- Getting back to a smaller, self contained code-base is sometimes a good idea.

## Installation

Download binaries for your system. Currently only 64-bit Linux, OSX and Windows platforms are supported. 

Links:
- [Linux](https://snipget.org/download/linux)
- [Mac OS](https://snipget.org/download/osx)
- [Windows](https://snipget.org/download/windows)

## Downloading snippets

Let's get started. Add the first snippet.

```sh
# Adds the latest version of this snippet. Saved in the current directory.
snipget get kai/router.js
```

```sh
# Saved in the utils directory (as utils/router.js).
snipget get kai/router.js utils
```

Add a specific version of the snippet

```sh
# Adds a specific version.
snipget get kai/1.3.4/router.js
```

Add the latest snippet for a fixed major/minor version

```sh
# Get the latest snippet conforming to major version 2, minor version 3.
# Maybe v2.3.6
snipget get kai/2.3/router

# Get the latest snippet conforming to major version 2.
# Maybe v2.4.1
snipget get kai/2/router.js
```

Print the contents of the file with curl.

```sh
# Prints the file contents to the console.
curl kai/router.js
```

```sh
# Lists all available versions of a snippet.
curl versions/kai/router.js
```

## snipget.json

Snippets downloaded with the 'get' command creates a snipget.json file in the current directory if one doesn't already exist in the current directory or in any of the parent directories. This file is used to track all the snippets used by a project.

To start using snipget for a project, create a blank snipget.json file in the project's base directory. Since this file exists now, all subsequent snipget commands invoked from within the project's path will use this file.

```sh
touch snipget.json
```

## Restoring all snippets

When invoked from a directory containing a snipget.json file, snipget will restore all snippets found in the snipget.json file.

```sh
# Call from a directory containing a snipget.json file
snipget restore
```

## Using curl or wget

All files and directories are downloadable using wget or curl. Directories are stored as a a compressed archive (tar.gz). Note that using wget or curl does not create or update the snipget.json file, which makes managing dependencies harder.

To download kai's latest router.js use the following curl command.

```sh
curl https://snipget.org/kai/router.js --output utils/router.js
```

To download a specific version use:

```sh
curl https://snipget.org/kai/1.3.0/router.js --output utils/router.js
```

To download the latest major version:

```sh
# Download the latest with major version 1
curl https://snipget.org/kai/1/router.js --output utils/router.js
```

To download a directory:

```sh
curl https://snipget.org/kai/3.0.1/webtools.tar.gz | tar xvf
```

## Updating and Deleting Snippets

Update a specific snippet to the latest version.

```sh
# This gets the latest published version of the snippet
snipget get kai/router.js
```

Update all snippets found in the snipget.json for the current directory. Thrown an error if snipget.json is not found.

```sh
# This updates all snippets found in snipget.json to the latest versions.
snipget upgrade
```

This updates all snippets while retaining the major version.

```sh
snipget upgrade --lock major
```

This updates all snippets to the latest patch versions.

```sh
snipget upgrade --lock minor
```

## Authentication

Create an account. If the username is available, this creates an ed25519 key pair in $HOME/.snipget/kai.secret.

```sh
snipget signup kai
```

Your public key can now be seen by everyone.

```sh
snipget get keys/kai
```

To change your key, signup again with the overwrite flag.

```sh
snipget signup jeswin --recreate
```

You can create as many accounts as you want on the same machine.

```sh
# Create a user named jeswin. Now you have two ids, kai and jeswin. 
# The newly created id will become the default identity.
snipget signup jeswin
```

If you have multiple identities, switch your default identity with the 'id' command.

```sh
# Switch id back to kai.
snipget id kai
```

## Publishing

Publish a file snippet. The current patch version is updated. The first parameter is your username.

```sh
# Increments the patch version as well.
# eg: v1.4.4 -> v1.4.5. Or creates v0.0.1 if it's a new snippet.
snipget post kai router.js
```

Publish and update the minor version.

```sh
# Increments the minor version, and sets the patch version to zero.
# eg: v1.4.4 -> v1.5.0
snipget post kai router.js --minor
```

Publish and update the major version.

```sh
# Increments the major version, and sets others to zero.
# eg: v0.4.0 -> v1.0.0
snipget post kai router.js --major
```

Publish a directory. 

```sh
snipget post kai easy-router/
```

Publish and give a different name to the snippet

```sh
# Download with snipget get kai/super-router.js
snipget post kai router.js --name super-router.js
```

## Deleting

Delete a version of a snippet. If it was the latest, the previous version becomes current.

```sh
# Delete the version 1.4.0.
snipget delete kai/1.4.0/router.js
```

Delete the latest version of a snippet. The previous version becomes current.

```sh
# Delete the latest version
snipget delete kai/router.js
```

Delete all versions of a snippet. Use caution.

```sh
# Delete a file
snipget delete kai/router.js --all

# Delete all versions of a directory
snipget delete kai/easy-router --all
```

## Teams

You can create a team and add more people to it. You'll be the admin. Both admins and normal users can publish snippets, but only admins can add other users.

Creating a Team with the default identity.

```sh
# Create a team called foodevs
snipget post teams foodevs
```

If you have multiple identities and you don't want to use the default id, you can explicitly specify the id. 

```sh
snipget post teams foodevs --id jeswin
```

You're already an admin. You can add admins and normal users.

```sh
# Add alice as admin
snipget post teams/foodevs/admins alice

# Add bob as a normal user
snipget post teams/foodevs/users bob
```

Or remove them. You cannot remove yourself, but another admin can.

```sh
# Remove alice as admin
snipget delete teams/foodevs/admins/alice
```

All published snippets live under the team's namespace.

```sh
# Download a snippet from the team 'foodevs'
snipget get foodevs/router.js
```

## Publishing in Teams

Publishing team snippets is very similar to what we saw earlier.

```sh
# Publishing a snippet
snipget post foodevs router.js
```

```sh
# Removing
snipget delete foodevs/router.js
```

Teams can publish private snippets. Only members of the team foodevs will be able to read the file contents.

```sh
snipget post foodevs router.js --private
```

## Snipget repository

snipget.org is the default snipget repository. 

But it could be overridden in two ways.
- snipget.json file
- SNIPGET_HOST environment variable.

Here's an example snipget.json file.

```json
{
  "snipgetHost": "snipget.example.com",
}
```

