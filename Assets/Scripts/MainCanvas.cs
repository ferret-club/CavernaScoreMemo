using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCanvas : MonoBehaviour {

    public int myNumber;

    public List<InputFieldUpdate> inputFieldUpdates = new List<InputFieldUpdate>();

    void Start() {
        linkFields();
    }

    private void linkFields() {
        inputFieldUpdates.Add(this.transform.FindChild("Animals").FindChild("Sheep").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Animals").FindChild("Ass").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Animals").FindChild("Boar").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Animals").FindChild("Cattle").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Animals").FindChild("Dog").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Crops").FindChild("Wheat").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Crops").FindChild("Vegetable").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Resources").FindChild("Ruby").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Resources").FindChild("Dwarf").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Resources").FindChild("Money").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Buildings").FindChild("Farm").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Buildings").FindChild("Vine").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Buildings").FindChild("Room").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Buildings").FindChild("WereHouse").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("Buildings").FindChild("BedRoom").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("TakeOffPoints").FindChild("BlankSpace").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
        inputFieldUpdates.Add(this.transform.FindChild("TakeOffPoints").FindChild("Beggar").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate);
    }

    public void init() {
//        InputFieldUpdate sheep = this.transform.FindChild("Animals").FindChild("Sheep").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        sheep.setInputField(0);
//        InputFieldUpdate ass = this.transform.FindChild("Animals").FindChild("Ass").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        ass.setInputField(0);
//        InputFieldUpdate boar = this.transform.FindChild("Animals").FindChild("Boar").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        boar.setInputField(0);
//        InputFieldUpdate cattle = this.transform.FindChild("Animals").FindChild("Cattle").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        cattle.setInputField(0);
//        InputFieldUpdate dog = this.transform.FindChild("Animals").FindChild("Dog").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        dog.setInputField(0);
//        InputFieldUpdate wheat = this.transform.FindChild("Crops").FindChild("Wheat").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        wheat.setInputField(0);
//        InputFieldUpdate vegetable = this.transform.FindChild("Crops").FindChild("Vegetable").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        vegetable.setInputField(0);
//        InputFieldUpdate ruby = this.transform.FindChild("Resources").FindChild("Ruby").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        ruby.setInputField(0);
//        InputFieldUpdate dwarf = this.transform.FindChild("Resources").FindChild("Dwarf").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        dwarf.setInputField(0);
//        InputFieldUpdate money = this.transform.FindChild("Resources").FindChild("Money").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        money.setInputField(0);
//        InputFieldUpdate farm = this.transform.FindChild("Buildings").FindChild("Farm").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        farm.setInputField(0);
//        InputFieldUpdate vine = this.transform.FindChild("Buildings").FindChild("Vine").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        vine.setInputField(0);
//        InputFieldUpdate room = this.transform.FindChild("Buildings").FindChild("Room").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        room.setInputField(0);
//        InputFieldUpdate wereHouse = this.transform.FindChild("Buildings").FindChild("WereHouse").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        wereHouse.setInputField(0);
//        InputFieldUpdate bedRoom = this.transform.FindChild("Buildings").FindChild("BedRoom").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        bedRoom.setInputField(0);
//        InputFieldUpdate blankSpace = this.transform.FindChild("TakeOffPoints").FindChild("BlankSpace").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        blankSpace.setInputField(0);
//        InputFieldUpdate beggar = this.transform.FindChild("TakeOffPoints").FindChild("Beggar").FindChild("Score").gameObject.GetComponent<InputFieldUpdate>() as InputFieldUpdate;
//        beggar.setInputField(0);
        foreach(var i in inputFieldUpdates) {
            i.setInputField(0);
        }

        SumField sumField = this.transform.FindChild("Summary").FindChild("Total").FindChild("SumField").gameObject.GetComponent<SumField>() as SumField;
        sumField.init();
    }
}
