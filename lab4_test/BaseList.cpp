#include "BaseList.h"
#include <iostream>

int BaseList::Count() { return count; }

void BaseList::Print() {
    for (int i = 0; i < count; i++) {
        std::cout << (*this)[i] << " ";
    }
    std::cout << std::endl;
}

void BaseList::AssignFrom(BaseList* source) {
    Clear();
    for (int i = 0; i < source->Count(); i++) {
        Add((*source)[i]);
    }
}

void BaseList::AssignTo(BaseList* dest) {
    dest->AssignFrom(this);
}

BaseList* BaseList::Clone() {
    BaseList* clone = EmptyClone();
    clone->AssignFrom(this);
    return clone;
}

void BaseList::Sort() {
    for (int i = 0; i < Count(); i++) {
        for (int j = i + 1; j < Count(); j++) {
            if ((*this)[i] > (*this)[j]) {
                int temp = (*this)[i];
                (*this)[i] = (*this)[j];
                (*this)[j] = temp;
            }
        }
    }
}

bool BaseList::IsEqual(BaseList* otherList) {
    if (otherList == nullptr)
        return false;
        return false;

    if (this->Count() != otherList->Count())
        return false;

    for (int i = 0; i < this->Count(); i++) {
        if ((*this)[i] != (*otherList)[i])
            return false;
    }

    return true;
}
