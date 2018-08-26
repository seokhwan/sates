package com.sates.test.java;

public enum TEST_RESULT
{
    INVALID(1),
    OK(20180417),
    NG(0);

    private int value;

    private TEST_RESULT(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
