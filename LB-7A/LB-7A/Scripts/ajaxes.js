var contacts = [];

function getContacts() {
    $.ajax({
        url: "/ts",
        type: "GET",
        success: data => {
            contacts = [...data];
            displayContacts();
        }
    });
}

function addContact() {
    var phoneContact = {
        name: document.getElementById("name").value,
        phone: document.getElementById("phone").value
    };

    $.ajax({
        url: "/ts",
        type: "POST",
        data: phoneContact,
        success: contact => {
            contacts = [...contacts, contact];
            displayContacts();
        }
    });
}

function updateContact() {
    var phoneContact = {
        id: document.getElementById("idUpdate").value,
        name: document.getElementById("nameUpdate").value,
        phone: document.getElementById("phoneUpdate").value
    };

    $.ajax({
        url: "/ts",
        type: "PUT",
        data: phoneContact,
        success: contact => {
            contacts = contacts.map(x => {
                return x.Id === contact.Id
                    ? {
                        ...contact
                    }
                    : x;
            });

            displayContacts();
        }
    });
}

function removeContact(id) {
    $.ajax({
        url: `/ts/${id}`,
        type: "DELETE",
        success: () => {
            contacts = contacts.filter(x => x.Id !== id);
            displayContacts();
        }
    });
}

function displaySelectedContact(id, name, phone) {
    document.getElementById("idUpdate").value = id;
    document.getElementById("nameUpdate").value = name;
    document.getElementById("phoneUpdate").value = phone;
}

function displayContacts() {
    document.getElementById("contacts-root").innerHTML = "";

    contacts.forEach(contact => {
        var childElement = document.createElement("div");
        childElement.innerHTML += `${contact.Name} ${contact.Phone}`;

        var onClickAttribute = document.createAttribute("onclick");
        onClickAttribute.value = `removeContact(${contact.Id})`;

        var onClickAttributeUpdate = document.createAttribute("onclick");
        onClickAttributeUpdate.value = `displaySelectedContact(${contact.Id}, "${contact.Name}", "${contact.Phone}")`;

        var removeButton = document.createElement("button");
        var text = document.createTextNode("Remove");
        removeButton.appendChild(text);
        removeButton.setAttributeNode(onClickAttribute);

        var updateButton = document.createElement("button");
        var textUpdate = document.createTextNode("Update");
        updateButton.appendChild(textUpdate);
        updateButton.setAttributeNode(onClickAttributeUpdate);

        childElement.appendChild(removeButton);
        childElement.appendChild(updateButton);
        document.getElementById("contacts-root").appendChild(childElement);
    });
}