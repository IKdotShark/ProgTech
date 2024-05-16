#ifndef CHAINLIST_H
#define CHAINLIST_H

#include "BaseList.h"

class ChainList : public BaseList {
private:
    struct Node {
        int data;
        Node* next;

        Node(int data, Node* next = nullptr) : data(data), next(next) {}
    };

    Node* head;

public:
    ChainList();
    ~ChainList();
    void Add(int data) override;
    void Insert(int pos, int data) override;
    void Delete(int pos) override;
    void Clear() override;
    int& operator[](int i) override;

private:
    Node* Find(int pos);
    BaseList* EmptyClone() override;
};

#endif // CHAINLIST_H
