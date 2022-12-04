# Easy Object Pool
EOP it's an easy way to make an object pool that has multiple objects all in the same code
## Usage

Just drag the EOP object to the hierarchy (Or drag the code to one of your gameobjects) and then add the data of your object.

**ID** is an int and it's used by EOP to search the desired game object.

**Name** it's only used as a way to remind yourself what object is it.

**Object prefab** is the game object that you are going to instantiate.

**Total objects** it's the amount of object you want to instantiate.

  

When you want to instantiate just use:

  

```sh

 EasyObjectPool.SharedInstance.GetPooledObject(id);

```

  

This will return you a GameObject that then you can use in any way you want

  

## Deactivate objects

  

The object needs to be deactivated to be removed by using:

  

```sh

 gameObject.SetActive(false);

```

## Other functions
You can deactivate all the objects of the same id by using:

  

```sh

 EasyObjectPool.SharedInstance.disableObjects(id);

```

  

You can deactivate all the objects by using:

  

```sh

 EasyObjectPool.SharedInstance.disableAllObjects();

```
### Contact Me

If you have anything to say send it to thewitch@witchdev.com