// Danh sách promotion code (Mã giảm giá)
let promotionCode = {
    A: 10,
    B: 20,
    C: 30,
    D: 40,
};
// Cập nhật tổng tiền
function updateTotalMoney(arr) {
    // Có mã giảm giá hay không?
    // Mã giảm giá có hợp lệ hay không?
    let data = checkPromotion();

    if (data) {
        discountMoney = (totalMoney * data) / 100;
        discount.classList.remove('hide');
    } else {
        discount.classList.add('hide');
    }
}

// Kiểm tra mã giảm giá
function checkPromotion() {
    let value = inputPromotion.value;
    if (promotionCode[value]) {
        return promotionCode[value];
    }
    return 0;
}
});

