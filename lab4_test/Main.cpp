#include <iostream>
#include <cstdlib>
#include <ctime>
#include "ArrayList.h"
#include "ChainList.h"

int main() {
    srand(time(nullptr));

    BaseList* array = new ArrayList();
    BaseList* chain = new ChainList();
    int count = 5 + rand() % 15;
    for (int i = 0; i < count; i++) {
        int item = rand() % 1000;
        array->Add(item);
        chain->Add(item % 100);
    }
    BaseList* array2 = array->Clone();
    BaseList* chain2 = chain->Clone();
    array->Sort();
    chain->Sort();
    bool t = false;
    while (array->Count() > 0) {
        for (int i = 0; i < array2->Count(); i++) {
            if ((*array2)[i] == (*array)[0]) {
                array->Delete(0);
                array2->Delete(i);
                t = true;
                break;
            }
        }
        if (!t) {
            std::cout << "Error" << std::endl;
            break;
        }
    }
    std::cout << "Array Sort Test: " << t << std::endl;
    t = false;
    while (chain->Count() > 0) {
        for (int i = 0; i < chain2->Count(); i++) {
            if ((*chain2)[i] == (*chain)[0]) {
                chain->Delete(0);
                chain2->Delete(i);
                t = true;
                break;
            }
        }
        if (!t) {
            std::cout << "Error" << std::endl;
            break;
        }
    }
    std::cout << "Chain Sort Test: " << t << std::endl;
    for (int i = 0; i < 15000; i++) {
        int operation = rand() % 5;
        int item = rand() % 100;
        int pos = rand() % 1000;
        switch (operation) {
        case 0:
            array->Add(item);
            chain->Add(item);
            break;
        case 1:
            array->Delete(pos);
            chain->Delete(pos);
            break;
        case 2:
            array->Insert(pos, item);
            chain->Insert(pos, item);
            break;
        case 3:
            array->Clear();
            chain->Clear();
            break;
        case 4:
            (*array)[pos] = item;
            (*chain)[pos] = item;
            break;
        }
    }
    if (!array->IsEqual(chain))
        std::cout << "Error" << std::endl;
    else
        std::cout << "Successful" << std::endl;
    delete array;
    delete chain;
    delete array2;
    delete chain2;
    return 0;
}
