# Complete Git Workflow: Fork → Branch → Push → Pull Request

This guide explains the professional workflow for contributing to a
project from another GitHub account using feature branches and Pull
Requests.

------------------------------------------------------------------------

## Step 1: Fork the Repository

Go to the original repository on GitHub and click the **Fork** button.\
This creates a copy of the repository in your GitHub account.

------------------------------------------------------------------------

## Step 2: Clone Your Fork

``` bash
git clone https://github.com/your-username/repo.git
cd repo
```

------------------------------------------------------------------------

## Step 3: Add Upstream (Original Repository)

``` bash
git remote add upstream https://github.com/main-user/repo.git
git remote -v
```

You should see: - origin → your fork - upstream → original repository

------------------------------------------------------------------------

## Step 4: Create a New Feature Branch

Always work on a new branch instead of main.

``` bash
git checkout -b feature/my-update
```

------------------------------------------------------------------------

## Step 5: Make Changes and Commit

``` bash
git add .
git commit -m "Add new feature"
```

------------------------------------------------------------------------

## Step 6: Push Branch to Your GitHub

``` bash
git push origin feature/my-update
```

This pushes your branch only to your GitHub account.

------------------------------------------------------------------------

## Step 7: Create Pull Request

1.  Go to your forked repository.
2.  Click **Pull Request**.
3.  Set:
    -   Base repository → main-user/repo
    -   Base branch → main
    -   Compare branch → feature/my-update
4.  Submit Pull Request.

------------------------------------------------------------------------

## Syncing with Main Repository

If original repo gets updated:

``` bash
git checkout main
git fetch upstream
git merge upstream/main
git push origin main
```

------------------------------------------------------------------------

## Professional Best Practices

-   Never push directly to main
-   Always use feature branches
-   Keep commit messages meaningful
-   Raise Pull Request for review
-   Sync your fork regularly
