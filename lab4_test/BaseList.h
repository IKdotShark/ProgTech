#ifndef BASELIST_H
#define BASELIST_H

class BaseList {
protected:
    int count;

public:
    int Count();
    virtual void Add(int a) = 0;
    //virtual int& operator[](int i); 
    virtual void Insert(int pos, int a) = 0;
    virtual void Delete(int pos) = 0;
    virtual void Clear() = 0;
    virtual int& operator[](int i) = 0;
    virtual void Print();
    virtual void AssignFrom(BaseList* source);
    virtual void AssignTo(BaseList* dest);
    virtual BaseList* Clone();
    virtual void Sort();
    virtual bool IsEqual(BaseList* otherList);

protected:
    virtual BaseList* EmptyClone() = 0;
};

#endif // BASELIST_H
