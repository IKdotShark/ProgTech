#ifndef ARRAYLIST_H
#define ARRAYLIST_H

#include "BaseList.h"

class ArrayList : public BaseList {
private:
    int* array;
    int capacity;

public:
    ArrayList();
    ~ArrayList();
    void Add(int a) override;
    void Insert(int pos, int a) override;
    void Delete(int pos) override;
    void Clear() override;
    int& operator[](int i) override;

private:
    void EnsureCapacity();
    BaseList* EmptyClone() override;
};

#endif // ARRAYLIST_H
