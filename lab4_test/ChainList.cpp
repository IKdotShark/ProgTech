#include "ChainList.h"

ChainList::ChainList() : head(nullptr) {}

ChainList::~ChainList() {
    Node* current = head;
    while (current != nullptr) {
        Node* next = current->next;
        delete current;
        current = next;
    }
}

void ChainList::Add(int data) {
    if (head == nullptr) {
        head = new Node(data);
    }
    else {
        Node* lastNode = Find(count - 1);
        lastNode->next = new Node(data);
    }
    count++;
}

void ChainList::Insert(int pos, int data) {
    if (pos < 0 || pos > count) {
        return;
    }

    if (pos == 0) {
        head = new Node(data, head);
    }
    else {
        Node* prev = Find(pos - 1);
        prev->next = new Node(data, prev->next);
    }
    count++;
}

void ChainList::Delete(int pos) {
    if (pos < 0 || pos >= count) {
        return;
    }

    if (pos == 0) {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
    else {
        Node* prev = Find(pos - 1);
        Node* temp = prev->next;
        prev->next = temp->next;
        delete temp;
    }
    count--;
}

void ChainList::Clear() {
    Node* current = head;
    while (current != nullptr) {
        Node* next = current->next;
        delete current;
        current = next;
    }
    head = nullptr;
    count = 0;
}

int& ChainList::operator[](int i) {
    static int dummy = 0;
    Node* node = Find(i);
    if (node == nullptr) {
        return dummy;
    }
    return node->data;
}

ChainList::Node* ChainList::Find(int pos) {
    if (pos >= count) {
        return nullptr;
    }

    int i = 0;
    Node* p = head;
    while (p != nullptr && i < pos) {
        p = p->next;
        i++;
    }

    return p;
}

BaseList* ChainList::EmptyClone() {
    return new ChainList();
}
