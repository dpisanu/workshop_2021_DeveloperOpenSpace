# Challenge 7

## How to pinpoint a change on my map?

Great, we can now map out the complete dependencies of a Test assembly. 
In order to pinpoint changes though we need to introduce our Fingerprint mechanism.

The logic steps here are:

- Loop through Test assemblies
  - Loop through dependencies per Test assembly
    - Check if Fingerprint of dependency changed
      - Remember new Fingerprint of changed dependency
- Store all new Fingerprints

#### Task: Identify all dependency changes, give a list of Test assemblies affected, store new Fingerprint values

[🕵️‍♀️ Possible solution](./Solutions/challenge7.md)

---------------------------------------
[⏭ Next challenge](./challenge8.md)

[🚦 Return to start](./start.md)