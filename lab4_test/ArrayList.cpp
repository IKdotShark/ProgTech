#include "ArrayList.h"
#include <cstdlib>
#include <ctime>

ArrayList::ArrayList() {
    array = nullptr;
    capacity = 0;
    count = 0;
}

ArrayList::~ArrayList() {
    delete[] array;
}

void ArrayList::Add(int a) {
    EnsureCapacity();
    array[count] = a;
    count++;
}

void ArrayList::Insert(int pos, int a) {
    if (pos < 0 || pos > count) {
        return;
    }

    EnsureCapacity();

    for (int i = count; i > pos; i--) {
        array[i] = array[i - 1];
    }

    array[pos] = a;
    count++;
}

void ArrayList::Delete(int pos) {
    if (pos < 0 || pos >= count) {
        return;
    }

    for (int i = pos; i < count - 1; i++) {
        array[i] = array[i + 1];
    }

    count--;
}

void ArrayList::Clear() {
    delete[] array;
    array = nullptr;
    count = 0;
    capacity = 0;
}

int& ArrayList::operator[](int i) {
    static int dummy = 0;
    if (i < 0 || i >= count) {
        return dummy;
    }

    return array[i];
}

void ArrayList::EnsureCapacity() {
    if (count == capacity) {
        int newCapacity = (capacity == 0) ? 2 : capacity * 2;
        int* newArray = new int[newCapacity];
        for (int i = 0; i < count; i++) {
            newArray[i] = array[i];
        }
        delete[] array;
        array = newArray;
        capacity = newCapacity;
    }
}

BaseList* ArrayList::EmptyClone() {
    return new ArrayList();
}
