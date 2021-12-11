class ArtGallery {

    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            "picture": 200,
            "photo": 50,
            "item": 250
        };
        this.listOfArticles = [];
        this.guests = [];
    };

    addArticle(articleModel, articleName, quantity) {
        let articleModelToLowerCase = articleModel.toLowerCase();
        const isValidArticModel = Object.entries(this.possibleArticles).some(a => a[0] == articleModelToLowerCase);
        const currentArticle = this.listOfArticles.find(a => a.articleName == articleName);
        if (!this.possibleArticles.hasOwnProperty(articleModelToLowerCase)) {
            throw new Error('This article model is not included in this gallery!');
        };

        if (currentArticle != undefined &&
            currentArticle.articleModel == articleModelToLowerCase) {

            this.listOfArticles.find(a => a.articleName == articleName).quantity += Number(quantity);

        } else {
            this.listOfArticles.push({
                articleModel: articleModelToLowerCase,
                articleName: articleName,
                quantity: quantity,
            });
        };

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        const isGuestPresent = this.guests.find(g => g.guestName == guestName);
        let currentPoints = 50;

        if (personality == 'Vip') {
            currentPoints = 500;
        }

        if (personality == 'Middle') {
            currentPoints = 250;
        }

        if (isGuestPresent) {
            throw new Error(`${guestName} has already been invited.`);
        } else {
            this.guests.push({
                guestName: guestName,
                points: currentPoints,
                purchaseArticle: 0,
            })
        }

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        const isExistArticle = this.listOfArticles.find(a => a.articleName == articleName && a.articleModel == articleModel.toLowerCase());
        const isExistGuest = this.guests.find(g => g.guestName == guestName);
        const necessaryPoints = this.possibleArticles[articleModel];

        if (!isExistArticle) {
            throw new Error("This article is not found.");
        }

        if (isExistArticle.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        if (!isExistGuest) {
            return "This guest is not invited.";
        }

        if (isExistGuest.points < necessaryPoints) {
            return "You need to more points to purchase the article.";
        } else {
            isExistGuest.points -= necessaryPoints;
            isExistArticle.quantity --;
            isExistGuest.purchaseArticle++;
        }

        return `${guestName} successfully purchased the article worth ${necessaryPoints} points.`
    }

    showGalleryInfo(criteria) {
        let result = [];

        if (criteria == "article") {
            result.push('Articles information:');

            this.listOfArticles.forEach(a => {
                result.push(`${a.articleModel} - ${a.articleName} - ${a.quantity}`);
            });
        }

        if (criteria == "guest") {
            result.push("Guests information:");

            this.guests.forEach(g => {
                result.push(`${g.guestName} - ${g.purchaseArticle}`);
            });
        }

        return result.join('\n').trim();
    }
}

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip'));
// console.log(artGallery.inviteGuest('Peter', 'Middle'));
// console.log(artGallery.inviteGuest('John', 'Middle'));

// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));


const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));
