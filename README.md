# snipget (Proposed design)

Platform-agnostic Snippets Manager.

The snippets may be committed into your source control, or not; depending on size constraints. It might make sense for small files such as 'capitalize.go' to be added to your source-code files and be committed into your version control. snipget tracks all downloaded snippets in file named 'snipget.json'. This file (snipget.json) is also expected to be committed to your source control.

## Why?

- Package management approaches (such as npm) result in 100s of MBs of downloads
- Semver ranges are a security risk. The next patch version could be malicious.
- We need to get back to smaller, self contained snippets and libs.

## Installation

Download binaries for your system. Currently only 64-bit Linux, OSX and Windows platforms are supported. 

Links:
- [Linux](https://snipget.com/download/linux)
- [Mac OS](https://snipget.com/download/osx)
- [Windows](https://snipget.com/download/windows)

## Downloading snippets

All snippets are namespaced by the author's or team's id: author_id/snippet_name

```sh
# Adds the latest version of this snippet.
snipget get kai/router.js
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

Add to a specific location.

```sh
# Saves the snippet in a specific directory. Creates dir if missing.
snipget get kai/router.js vendor/utils/
```

Print the contents of the file. Does not add to snipget.json.

```sh
# Prints the file contents to the console and doesn't save it.
snipget get kai/router.js --print
```

```sh
# Lists all available versions of the snippet.
snipget get kai/~versions/router.js --print
```

# Restoring all snippets

Snipget can restore all snippets from the snipget.json file. The snipget.json file is created when you use snipget add. As we discussed previously, this file must be committed to your version control.

```sh
snipget restore
```

# Using Curl

Snipget snippets are downloadable using wget or curl. Directories are stored as a a compressed archive (tar.gz).

To download kai's latest router.js use the following curl command.

```sh
curl https://snipget.com/kai/router.js --output utils/router.js
```

To download a specific version use:

```sh
curl https://snipget.com/kai/1.3.0/router.js --output utils/router.js
```

To download the latest major version:

```sh
# Download the latest with major version 1
curl https://snipget.com/kai/1/router.js --output utils/router.js
```

To download a directory:

```sh
curl https://snipget.com/kai/3.0.1/webtools.tar.gz | tar xvf
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

## Authenticating

Authentication is required if you want to publish and update snippets.

Create an account.

```sh
# You will be asked for password. snipget signup [username]
snipget signup 
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

# Teams

You can create a team and add more people to it. You'll be the admin. Both admins and normal users can publish snippets, but only admins can add other users.

Creating a Team.

```sh
# Create a team called foodevs
snipget post teams foodevs
```

You can add other admins and normal users.

```sh
# Add alice as admin
snipet post teams/foodevs/admins alice

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

# Publishing in Teams

Publishing team snippets is very similar to what we saw earlier.

```sh
# Publishing a snippet
snipget post foodevs router.js
```

```sh
# Removing
snipet delete foodevs/router.js
```

# Private Snippets (Non-MVP features)

A pair of ed25519 cryptographic keys is already created for you when you login. This key named 'default' stored in the file 'default.key' under the .snipget directory inside your home directory.

You can print a public key with the 'publickey' command.

```sh
# If you're alice, prints alice:XJliwwyUkfCynOSx8++N8H/YP1ft31r6ptwvG6yHjLs=
snipget publickey
```

Now to publish a new private snippet, you need to obtain the public keys of people who should be given access. Then use the 'key' option while publishing to allow access. Your own default key is automatically added.

The key option can either
- public_key
- identifier@public_key

It is strongly recommended that you add an identifier, since it allows you to manage keys later.

```sh
# Upload an encrypted snippet readable by you, alice and bob
snipget pub router.js \
--key alice@XJliwwyUkfCynOSx8++N8H/YP1ft31r6ptwvG6yHjLs= \
--key bob@IBOOMgjU9o/GBuPH0cF9RzuUsNeQ21Mu106w1e0tlqU=
```

Snipget itself will not be able to decrypt the file contents since the original unencrypted content is never sent to snipget servers.

To add a new public key to an existing snippet, use the addkey command.

```sh
# Add two keys (and call them bob and carol)
snipget getkey router.js bob@IBOOMgjU9o/GBuPH0cF9RzuUsNeQ21Mu106w1e0tlqU= \
carol@klajshdfs/HSDFSkjsRzuUsNeQ21Mu106w1e0tlqU=
```

To remove someone's access to an existing snippet, use the 'rmkey' command.

```sh
snipget rmkey router.js IBOOMgjU9o/GBuPH0cF9RzuUsNeQ21Mu106w1e0tlqU=
```

You can also remove someone with the identifier.

```sh
snipget rmkey router.js IBOOMgjU9o/GBuPH0cF9RzuUsNeQ21Mu106w1e0tlqU=
```

Similarly, encryption works for team namespaces as well. Here's how to publish an encrypted snippet within a team. Team members will need their keys added to be able to view the file contents.

```sh
snipget pub router.js \
--team foodevs
--key alice@XJliwwyUkfCynOSx8++N8H/YP1ft31r6ptwvG6yHjLs= \
--key bob@IBOOMgjU9o/GBuPH0cF9RzuUsNeQ21Mu106w1e0tlqU=
```

You can create additional keys as well. While downloading encrypted snippets all keys are tried until a match is found, or all keys are exhausted. The following example creates a myworkkey file in the .snipget directory.

```sh
snipget createkey myworkkey
```

